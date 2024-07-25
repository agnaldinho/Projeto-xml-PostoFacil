﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;
using static PortaFacil.personalizacao;

namespace PortaFacil
{
    public partial class ImportarClient : Form
    {
        private BancoDeDados banco;
        private HashSet<string> cnpjsAdicionados;
        private string pastaXml = string.Empty;

        public ImportarClient()
        {
            InitializeComponent();
            InicializarListView(); 
            personalizarbotao();
            banco = new BancoDeDados();
            banco.ConnectionString = BancoDeDados.SavedConnectionString;
            cnpjsAdicionados = new HashSet<string>();
            CarregarComboBoxEmpresa();
            btnImportar.Enabled = false;
            

        }

        private void InicializarListView()
        {
            // Configura o ListView
            lvDados.View = View.Details;
            lvDados.Columns.Add("Cnpj", 150);
            lvDados.Columns.Add("Nome", 250);
            lvDados.Columns.Add("Ie", 150);
            lvDados.Columns.Add("Rua", 200);
            lvDados.Columns.Add("Número", 150);
            lvDados.Columns.Add("Bairro", 200);
            lvDados.Columns.Add("Cidade", 200);
            lvDados.Columns.Add("Estado", 150);


        }
        private void LerArquivoXmlCFe(string xmlArquivo)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlArquivo);

                XmlElement root = xmlDoc.DocumentElement;


                Action processXmlNode = () => 
                {
                    foreach (XmlNode node in root.SelectNodes("//dest"))
                    {
                        string cnpj = node["CNPJ"]?.InnerText;
                        string nome = node["xNome"]?.InnerText;

                        string ie = null;
                        string rua = null;
                        string numero = null;
                        string bairro = null;
                        string cidade = null;
                        string estado = null;

                        XmlNode infAdicNode = root.SelectSingleNode("//infAdic");
                        if (infAdicNode != null)
                        {
                            string infCpl = infAdicNode["infCpl"]?.InnerText;
                            if (infCpl != null)
                            {
                                ie = Regex.Match(infCpl, @"IE:\s*(\d+)").Groups[1].Value;
                                var enderecoMatch = Regex.Match(infCpl, @"ENDEREC:\s*(.*?),\s*(\d+)\s*-\s*(.*?)\s*-\s*::(.*?)\/(\w\w)");
                                if (enderecoMatch.Success)
                                {
                                    rua = enderecoMatch.Groups[1].Value.Trim();
                                    numero = enderecoMatch.Groups[2].Value.Trim();
                                    bairro = enderecoMatch.Groups[3].Value.Trim();
                                    cidade = enderecoMatch.Groups[4].Value.Trim();
                                    estado = enderecoMatch.Groups[5].Value.Trim();
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(cnpj) && !string.IsNullOrEmpty(nome) && !cnpjsAdicionados.Contains(cnpj))
                        {
                            cnpjsAdicionados.Add(cnpj); // Adiciona o CNPJ ao conjunto
                            ListViewItem item = new ListViewItem(cnpj);
                            item.SubItems.Add(nome);
                            item.SubItems.Add(ie);
                            item.SubItems.Add(rua);
                            item.SubItems.Add(numero);
                            item.SubItems.Add(bairro);
                            item.SubItems.Add(cidade);
                            item.SubItems.Add(estado);
                            lvDados.Items.Add(item);
                        }
                    }
                };
                if (lvDados.InvokeRequired)
                {
                    lvDados.Invoke(processXmlNode);
                }
                else
                {
                    processXmlNode();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler o arquivo XML '" + xmlArquivo + "': " + ex.Message);
            }
        }

        private void LerArquivoXmlNFCe(string xmlArquivo)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlArquivo);

                XmlElement root = xmlDoc.DocumentElement;
                if (root == null)
                {
                    MessageBox.Show("Documento XML inválido: root não encontrado.");
                    return;
                }

                // Gerenciamento de namespace
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                nsmgr.AddNamespace("nfe", "http://www.portalfiscal.inf.br/nfe");

                Action processXmlNode = () => 
                {
                    // Seleciona nós 'dest' dentro do namespace correto
                    foreach (XmlNode node in root.SelectNodes("//nfe:dest", nsmgr))
                    {
                        string cnpj = node["CNPJ"]?.InnerText;
                        string nome = node["xNome"]?.InnerText;

                        XmlNode enderecoNode = node["enderDest"];
                        string rua = enderecoNode?["xLgr"]?.InnerText ?? string.Empty;
                        string numero = enderecoNode?["nro"]?.InnerText ?? string.Empty;
                        string bairro = enderecoNode?["xBairro"]?.InnerText ?? string.Empty;
                        string cidade = enderecoNode?["xMun"]?.InnerText ?? string.Empty;
                        string estado = enderecoNode?["UF"]?.InnerText ?? string.Empty;

                        // Extrair IE do infCpl
                        string ie = ExtractIE(root.SelectSingleNode("//nfe:infCpl", nsmgr)?.InnerText);

                        if (!string.IsNullOrEmpty(cnpj) && !string.IsNullOrEmpty(nome) && !cnpjsAdicionados.Contains(cnpj))
                        {
                            cnpjsAdicionados.Add(cnpj); // Adiciona o CNPJ ao conjunto
                            ListViewItem item = new ListViewItem(cnpj);
                            item.SubItems.Add(nome);
                            item.SubItems.Add(ie);
                            item.SubItems.Add(rua);
                            item.SubItems.Add(numero);
                            item.SubItems.Add(bairro);
                            item.SubItems.Add(cidade);
                            item.SubItems.Add(estado);
                            lvDados.Items.Add(item);
                        }
                    }
                };

                if (lvDados.InvokeRequired)
                {
                    lvDados.Invoke(processXmlNode);
                }
                else
                {
                    processXmlNode();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler o arquivo XML: " + ex.Message);
            }
        }

        private string ExtractIE(string infCplText)
        {
            if (string.IsNullOrEmpty(infCplText))
            {
                return string.Empty;
            }

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"IE:\s*(\d+)");
            System.Text.RegularExpressions.Match match = regex.Match(infCplText);
            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        private void LerArquivoXmlNFe(string xmlArquivo)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlArquivo);
                // Gerenciamento de namespace
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                nsmgr.AddNamespace("nfe", "http://www.portalfiscal.inf.br/nfe");
                XmlElement root = xmlDoc.DocumentElement;

                if (root == null)
                {
                    MessageBox.Show("Documento XML inválido: root não encontrado.");
                    return;
                }

                Action processXmlNode = () =>
                {
                    // Seleciona nós 'dest' dentro do namespace correto
                    foreach (XmlNode node in root.SelectNodes("//nfe:dest", nsmgr))
                    {
                        string cnpj = node["CNPJ"]?.InnerText;
                        string nome = node["xNome"]?.InnerText;
                        string ie = node["IE"]?.InnerText;

                        if (node["enderDest"] == null)
                        {
                            MessageBox.Show("Endereço não encontrado no XML: " + xmlArquivo);
                            continue;
                        }

                        XmlNode enderecoNode = node["enderDest"];
                        string rua = enderecoNode?["xLgr"]?.InnerText ?? string.Empty;
                        string numero = enderecoNode?["nro"]?.InnerText ?? string.Empty;
                        string bairro = enderecoNode?["xBairro"]?.InnerText ?? string.Empty;
                        string cidade = enderecoNode?["xMun"]?.InnerText ?? string.Empty;
                        string estado = enderecoNode?["UF"]?.InnerText ?? string.Empty;

                        if (!string.IsNullOrEmpty(cnpj) && !string.IsNullOrEmpty(nome) && !cnpjsAdicionados.Contains(cnpj))
                        {
                            cnpjsAdicionados.Add(cnpj); // Adiciona o CNPJ ao conjunto
                            ListViewItem item = new ListViewItem(cnpj);
                            item.SubItems.Add(nome);
                            item.SubItems.Add(ie);
                            item.SubItems.Add(rua);
                            item.SubItems.Add(numero);
                            item.SubItems.Add(bairro);
                            item.SubItems.Add(cidade);
                            item.SubItems.Add(estado);
                            lvDados.Items.Add(item);
                        }
                    }
                };

                if (lvDados.InvokeRequired)
                {
                    lvDados.Invoke(processXmlNode);
                }
                else
                {
                    processXmlNode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler o arquivo XML: " + ex.Message);
            }
        }
        private string TruncarTexto(string texto, int maxLength)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return texto;
            }

            texto = texto.Trim();

            return texto.Length <= maxLength ? texto : texto.Substring(0, maxLength);
        }
        private void ImportarDados()
        {
            List<int> pessoaIds = new List<int>();
            Dictionary<int, HashSet<string>> cnpjsPorEmpresa = new Dictionary<int, HashSet<string>>();
            List<string> cnpjsDuplicados = new List<string>();

            using (FbConnection conn = new FbConnection(banco.ConnectionString))
            {
                try 
                {
                    conn.Open();
                    FbTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Carregar CNPJs existentes por empresa
                        string selectCnpjs = "SELECT num_cpf_cnpj, empresa_pessoa_id FROM pessoa";
                        using (FbCommand cmd = new FbCommand(selectCnpjs, conn, transaction))
                        {
                            using (FbDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string cnpj = reader.GetString(0);
                                    int empresaId = reader.GetInt32(1);

                                    if (!cnpjsPorEmpresa.ContainsKey(empresaId))
                                    {
                                        cnpjsPorEmpresa[empresaId] = new HashSet<string>();
                                    }

                                    cnpjsPorEmpresa[empresaId].Add(cnpj);
                                }
                            }
                        }

                        // Inserir registros na tabela pessoa
                        foreach (ListViewItem item in lvDados.Items)
                        {
                            string ie = item.SubItems[2].Text;
                            string nome = TruncarTexto(item.SubItems[1].Text, 40);
                            string cnpj = item.SubItems[0].Text;
                            int empresaId = Convert.ToInt32(cbEmpresa.SelectedValue);

                            // Verificar se o CNPJ já existe para a empresa
                            if (cnpjsPorEmpresa.ContainsKey(empresaId) && cnpjsPorEmpresa[empresaId].Contains(cnpj))
                            {
                                cnpjsDuplicados.Add(cnpj);
                                continue;
                            }

                            int novoCodigoPessoa = ObterNovoCodigoPessoa(conn, transaction);

                            string insertPessoa = "INSERT INTO pessoa (nome, num_cpf_cnpj, classe, empresa_pessoa_id, codigo, tipo_pessoa, num_rg) VALUES (@nome, @cnpj, 1, @empresa_id, @codigo, 'J', @ie)";
                            using (FbCommand cmd = new FbCommand(insertPessoa, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nome", nome);
                                cmd.Parameters.AddWithValue("@cnpj", cnpj);
                                cmd.Parameters.AddWithValue("@codigo", novoCodigoPessoa);
                                cmd.Parameters.AddWithValue("@ie", ie);
                                cmd.Parameters.AddWithValue("@empresa_id", empresaId);
                                cmd.ExecuteNonQuery();
                            }

                            AtualizarGeradorId(conn, transaction);

                            int pessoaId = ObterPessoaIdPorCodigo(conn, transaction, novoCodigoPessoa);
                            pessoaIds.Add(pessoaId);

                            // Adicionar CNPJ à lista de existentes para a empresa
                            if (!cnpjsPorEmpresa.ContainsKey(empresaId))
                            {
                                cnpjsPorEmpresa[empresaId] = new HashSet<string>();
                            }
                            cnpjsPorEmpresa[empresaId].Add(cnpj);
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erro ao inserir registros na tabela pessoa: " + ex.Message);
                        return;
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Erro: Necessario Configurar Banco de Dados");
                }
                
            }

            using (FbConnection conn = new FbConnection(banco.ConnectionString))
            {
                try 
                {
                    conn.Open();
                    FbTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        for (int i = 0; i < lvDados.Items.Count; i++)
                        {
                            ListViewItem item = lvDados.Items[i];
                            string rua = item.SubItems[3].Text;
                            string numero = item.SubItems[4].Text;
                            string bairro = item.SubItems[5].Text;
                            string cidade = item.SubItems[6].Text;
                            string estado = item.SubItems[7].Text;

                            string insertEndereco = "INSERT INTO endereco (pessoa_id, empresa_pessoa_id, ENDERECO, numero, bairro, cidade, uf,tipo_endereco) VALUES (@pessoa_id, @empresa_id, @rua, @numero, @bairro, @cidade, @estado, 2)";
                            using (FbCommand cmd = new FbCommand(insertEndereco, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@pessoa_id", pessoaIds[i]);
                                cmd.Parameters.AddWithValue("@rua", rua);
                                cmd.Parameters.AddWithValue("@numero", numero);
                                cmd.Parameters.AddWithValue("@bairro", bairro);
                                cmd.Parameters.AddWithValue("@cidade", cidade);
                                cmd.Parameters.AddWithValue("@estado", estado);
                                cmd.Parameters.AddWithValue("@empresa_id", cbEmpresa.SelectedValue);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Importação concluída com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }

                }
                catch (Exception ex) 
                {
                }
                
            }

            // Apresentar lista de CNPJs duplicados
            if (cnpjsDuplicados.Any())
            {
                string cnpjsDuplicadosMsg = "CNPJs já cadastrados: " + string.Join(", ", cnpjsDuplicados);
                MessageBox.Show(cnpjsDuplicadosMsg);
            }
            else
            {
                
            }
        }



        private int ObterNovoCodigoPessoa(FbConnection conn, FbTransaction transaction)
        {
            string selectQuery = "SELECT MAX(codigo) FROM pessoa WHERE empresa_pessoa_id = @empresa_id";
            using (FbCommand cmd = new FbCommand(selectQuery, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@empresa_id", cbEmpresa.SelectedValue);
                object resultado = cmd.ExecuteScalar();
                return resultado == DBNull.Value ? 1 : Convert.ToInt32(resultado) + 1;
            }
        }

        private int ObterPessoaIdPorCodigo(FbConnection conn, FbTransaction transaction, int codigo)
        {
            string selectQuery = "SELECT pessoa_id FROM pessoa WHERE codigo = @codigo AND empresa_pessoa_id = @empresa_id";
            using (FbCommand cmd = new FbCommand(selectQuery, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@empresa_id", cbEmpresa.SelectedValue);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void AtualizarGeradorId(FbConnection conn, FbTransaction transaction)
        {
            string updateQuery = "UPDATE gerador_id SET atual_id = atual_id + 1 WHERE tipo_entidade = 6 AND empresa_id = @empresa_id";
            using (FbCommand cmd = new FbCommand(updateQuery, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@empresa_id", cbEmpresa.SelectedValue);
                cmd.ExecuteNonQuery();
            }
        }
        private void CarregarComboBoxEmpresa()
        {
            try
            {
                cbTipoXml.DropDownStyle = ComboBoxStyle.DropDownList;
                cbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
                FbDataAdapter da;
                string query2 = "select * from empresa";
                da = new FbDataAdapter(query2, banco.ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    cbEmpresa.DataSource = dt;
                    cbEmpresa.DisplayMember = "nom_empresa";
                    cbEmpresa.ValueMember = "empresa_id";

                }
                else
                {
                    MessageBox.Show("Nenhuma empresa encontrada no banco de dados.", "Informação");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                {
                    pastaXml = folderBrowserDialog.SelectedPath;
                    MessageBox.Show("Pasta selecionada: " + pastaXml);
                    txtDiretorio.Text = pastaXml;

                    // Obter todos os arquivos XML nas subpastas
                    string[] arquivosXml = Directory.GetFiles(pastaXml, "*.xml", SearchOption.AllDirectories);

                }
            }
        }

        private void btnApresentar_Click_1(object sender, EventArgs e)
        {
            string tipoXml = cbTipoXml.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(tipoXml))
            {
                MessageBox.Show("Selecione um tipo de XML válido.");
                return;
            }

            carregamento telaCarregamento = new carregamento
            {
                TopLevel = false
            };

            this.Controls.Add(telaCarregamento);
            telaCarregamento.Location = new Point((this.ClientSize.Width - telaCarregamento.Width) / 2, (this.ClientSize.Height - telaCarregamento.Height) / 2);
            telaCarregamento.Show();
            telaCarregamento.BringToFront();
            telaCarregamento.Refresh();

            telaCarregamento.AtualizarProgresso(0);

            lvDados.Items.Clear();

            if (string.IsNullOrEmpty(pastaXml))
            {
                MessageBox.Show("Por favor, selecione uma pasta contendo os arquivos XML primeiro.");
                telaCarregamento.Close();
                return;
            }

            if (Directory.Exists(pastaXml))
            {
                Task.Run(() =>
                {
                    ProcessarArquivosXml(telaCarregamento, tipoXml);
                });
            }
            else
            {
                MessageBox.Show("A pasta especificada não existe.");
                telaCarregamento.Close();
            }

            btnImportar.Enabled = true;
        }

        private void btnImportar_Click_1(object sender, EventArgs e)
        {
            ImportarDados();
            lvDados.Items.Clear();
            btnImportar.Enabled = false;
        }

        private void personalizarbotao()
        {

            Color corRoxo = Color.FromArgb(0x28, 0x0A, 0x3C);
            IconManager.SetButtonIcon(btnImportar, Properties.Resources.Importar, 32, 32, ContentAlignment.BottomLeft, Color.Indigo, Color.White);
            //IconManager.SetButtonIcon(btnSelecionar, Properties.Resources.xml, 300, 50, ContentAlignment.TopCenter, corRoxo, corRoxo);
            IconManager.SetPicturebox(btnSelecionar, Properties.Resources.xml, 58, 58, corRoxo, corRoxo);
            IconManager.SetButtonIcon(btnApresentar, Properties.Resources.dados, 32, 32, ContentAlignment.BottomLeft, Color.Indigo, Color.White);

        }

        private void ProcessarArquivosXml(carregamento telaCarregamento, string tipoXml)
        {
            try
            {
                // Obtém a lista de arquivos XML na pasta e subpastas
                string[] arquivosXml = Directory.GetFiles(pastaXml, "*.xml", SearchOption.AllDirectories);
                int totalArquivos = arquivosXml.Length;
                int arquivosProcessados = 0;

                foreach (string arquivoXml in arquivosXml)
                {
                    switch (tipoXml)
                    {
                        case "CF-e":
                            LerArquivoXmlCFe(arquivoXml);
                            break;
                        case "NFC-e":
                            LerArquivoXmlNFCe(arquivoXml);
                            break;
                        case "NF-e":
                            LerArquivoXmlNFe(arquivoXml);
                            break;
                        default:
                            telaCarregamento.Invoke(new Action(() =>
                            {
                                MessageBox.Show("Tipo de XML desconhecido.");
                            }));
                            return;
                    }

                    // Atualiza a progressão
                    arquivosProcessados++;
                    int progresso = (int)((arquivosProcessados * 100.0) / totalArquivos);
                    telaCarregamento.Invoke(new Action(() => telaCarregamento.AtualizarProgresso(progresso)));
                }

                telaCarregamento.Invoke(new Action(() =>
                {
                }));
            }
            catch (Exception ex)
            {
                telaCarregamento.Invoke(new Action(() =>
                {
                    MessageBox.Show("Erro ao processar os arquivos XML: " + ex.Message);
                }));
            }
            finally
            {
                telaCarregamento.Invoke(new Action(telaCarregamento.Close));
            }
        }


    }
}
