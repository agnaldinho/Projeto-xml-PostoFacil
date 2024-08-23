using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Xml;
using FirebirdSql.Data.FirebirdClient;
using static PortaFacil.personalizacao;

namespace PortaFacil
{
    public partial class ImportarProduto : Form
    {
        private int contadorProdutos = 0;
        private string pastaXml = string.Empty;
        private BancoDeDados banco;
        private int ultimoProdutoId = 0;
        public ImportarProduto()
        {
            InitializeComponent();
            InicializarListView();
            personalizarbotao();
            banco = new BancoDeDados();
            banco.ConnectionString = BancoDeDados.SavedConnectionString;
            CarregarComboBoxEmpresa();
            btnImportar.Enabled = false;
        }

        

        private void InicializarListView()
        {
            lvDados.View = View.Details;
            lvDados.Columns.Add("Nome do Produto", 200);
            lvDados.Columns.Add("Ncm", 100);
            lvDados.Columns.Add("Unidade", 100);
            lvDados.Columns.Add("Preço", 100);
            lvDados.Columns.Add("Codigo de Tributação", 200);
            lvDados.Columns.Add("CST de Saida", 300);
            lvDados.Columns.Add("Anp", 100);
            lvDados.Columns.Add("Código Cest", 100);
        }


        private void personalizarbotao()
        {
            Color corRoxo = Color.FromArgb(0x28, 0x0A, 0x3C);
            IconManager.SetPicturebox(btnSelecionar, Properties.Resources.xml, 58, 58, corRoxo, corRoxo);    
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

        private void LerArquivoXmlCFe(string xmlArquivo)
        {
            try
            {
                if (lvDados == null)
                {
                    throw new InvalidOperationException("O controle lvDados não está inicializado.");
                }

                string[] palavrasChaveCombustivel = { "COMBUSTÍVEL", "GASOLINA", "ETANOL", "DIESEL", "GNV", "BS500", "S500", "S10", "ALCOOL" };

                Dictionary<string, string> cstNames = new Dictionary<string, string>
        {
            {"00", "00 - Produto Tributado"},
            {"10", "10 - Substituição tributária"},
            {"20", "20 - Redução de base de cálculo"},
            {"30", "30 - Não incidência"},
            {"40", "40 - Produto Isento"},
            {"41", "41 - Produto Isento"},
            {"50", "50 - Não incidência"},
            {"51", "51 - Não incidência"},
            {"60", "60 - Substituição tributária"},
            {"61", "61 - Monofásica"},
            {"70", "70 - Redução de base de cálculo"},
            {"90", "90 - Não incidência"},
        };

                Dictionary<string, string> cstSaidaNames = new Dictionary<string, string>
        {
            {"01", "01 - OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA BÁSICA"},
            {"02", "02 - OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA DIFERENCIADA"},
            {"04", "04 - OPERAÇÃO TRIBUTÁVEL MONOFÁSICA - REVENDA A ALÍQUOTA ZERO"},
            {"05", "05 - OPERAÇÃO TRIBUTÁVEL POR SUBSTITUIÇÃO TRIBUTÁRIA"},
            {"06", "06 - OPERAÇÃO TRIBUTÁVEL A ALÍQUOTA ZERO"},
            {"07", "07 - OPERAÇÃO ISENTA DA CONTRIBUIÇÃO"},
            {"08", "08 - OPERACAO SEM INCIDENCIA DA CONTRIBUICÃO"},
            {"49", "49 - OUTRAS OPERAÇÕES DE SAÍDA"},
            {"99", "99 - OUTRAS OPERAÇÕES"},
        };

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlArquivo);

                XmlElement root = xmlDoc.DocumentElement;

                Action processXmlNode = () =>
                {
                    foreach (XmlNode node in root.SelectNodes("//det"))
                    {
                        XmlNode prodNode = node.SelectSingleNode("prod");
                        XmlNode impostoNode = node.SelectSingleNode("imposto");

                        bool skipItem = false;

                        foreach (XmlNode childNode in prodNode.ChildNodes)
                        {
                            foreach (string palavra in palavrasChaveCombustivel)
                            {
                                if (childNode.InnerText.Contains(palavra))
                                {
                                    skipItem = true;
                                    break;
                                }
                            }
                            if (skipItem)
                            {
                                break;
                            }
                        }

                        string produto = prodNode["xProd"]?.InnerText;
                        if (lvDados.Items.Cast<ListViewItem>().Any(existingItem => existingItem.Text == produto))
                        {
                            skipItem = true;
                        }

                        if (skipItem)
                        {
                            continue;
                        }

                        string ncm = prodNode["NCM"]?.InnerText;
                        string unidade = prodNode["uCom"]?.InnerText;
                        string preco = prodNode["vUnCom"]?.InnerText;

                        ListViewItem newItem = new ListViewItem(produto);
                        newItem.SubItems.Add(ncm);
                        newItem.SubItems.Add(unidade);
                        newItem.SubItems.Add(preco);

                        // Processar o CST específico para este produto
                        XmlNode cstNode = impostoNode.SelectSingleNode(".//ICMS/*/CST");
                        string codigoTributacao = cstNode?.InnerText ?? "N/A";

                        string cstName = cstNames.ContainsKey(codigoTributacao) ? cstNames[codigoTributacao] : codigoTributacao;
                        newItem.SubItems.Add(cstName);

                        XmlNode cstSaida = impostoNode.SelectSingleNode(".//PIS/*/CST");
                        string cstSaida1 = cstSaida?.InnerText ?? "Não Encontrado: Padrão para incluir CST 01";
                        string cstSaidaName = cstSaidaNames.ContainsKey(cstSaida1) ? cstSaidaNames[cstSaida1] : cstSaida1;
                        newItem.SubItems.Add(cstSaidaName);

                        XmlNode anp = prodNode.SelectSingleNode(".//obsFiscoDet/xTextoDet");
                        string codigoAnp = anp?.InnerText ?? "";
                        newItem.SubItems.Add(codigoAnp);


                        string cest = prodNode["CEST"]?.InnerText;
                        newItem.SubItems.Add(cest);



                        lvDados.Items.Add(newItem);

                        contadorProdutos++;
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
                string errorMessage = "Erro ao ler o arquivo XML '" + xmlArquivo + "': " + ex.Message + "\n" + ex.StackTrace;
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => MessageBox.Show(errorMessage)));
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
        }

        private void LerArquivoXmlNFCe(string xmlArquivo)
        {
            try
            {
                string[] palavrasChaveCombustivel = { "COMBUSTÍVEL", "GASOLINA", "ETANOL", "DIESEL", "GNV", "BS500", "S500", "S10", "ALCOOL" };

                Dictionary<string, string> cstNames = new Dictionary<string, string>
                {
                    {"00", "00 - Produto Tributado"},
                    {"10", "10 - Substituição tributária"},
                    {"20", "20 - Redução de base de cálculo"},
                    {"30", "30 - Não incidência"},
                    {"40", "40 - Produto Isento"},
                    {"41", "41 - Produto Isento"},
                    {"50", "50 - Não incidência"},
                    {"51", "51 - Não incidência"},
                    {"60", "60 - Substituição tributária"},
                    {"61", "61 - Monofásica"},
                    {"70", "70 - Redução de base de cálculo"},
                    {"90", "90 - Não incidência"},
                };

                Dictionary<string, string> cstSaidaNames = new Dictionary<string, string>
                {
                    {"01", "01 - OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA BÁSICA"},
                    {"02", "02 - OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA DIFERENCIADA"},
                    {"04", "04 - OPERAÇÃO TRIBUTÁVEL MONOFÁSICA - REVENDA A ALÍQUOTA ZERO"},
                    {"05", "05 - OPERAÇÃO TRIBUTÁVEL POR SUBSTITUIÇÃO TRIBUTÁRIA"},
                    {"06", "06 - OPERAÇÃO TRIBUTÁVEL A ALÍQUOTA ZERO"},
                    {"07", "07 - OPERAÇÃO ISENTA DA CONTRIBUIÇÃO"},
                    {"08", "08 - OPERACAO SEM INCIDENCIA DA CONTRIBUICÃO"},
                    {"49", "49 - OUTRAS OPERAÇÕES DE SAÍDA"},
                    {"99", "99 - OUTRAS OPERAÇÕES"},
                };

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlArquivo);

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                nsmgr.AddNamespace("nfe", "http://www.portalfiscal.inf.br/nfe");

                XmlElement root = xmlDoc.DocumentElement;

                Action processXmlNode = () =>
                {
                    foreach (XmlNode node in root.SelectNodes("//nfe:det", nsmgr))
                    {
                        XmlNode prodNode = node.SelectSingleNode("nfe:prod", nsmgr);
                        XmlNode impostoNode = node.SelectSingleNode("nfe:imposto", nsmgr);

                        bool skipItem = false;

                        foreach (XmlNode childNode in prodNode.ChildNodes)
                        {
                            foreach (string palavra in palavrasChaveCombustivel)
                            {
                                if (childNode.InnerText.Contains(palavra))
                                {
                                    skipItem = true;
                                    break;
                                }
                            }
                            if (skipItem)
                            {
                                break;
                            }
                        }

                        string produto = prodNode["xProd"]?.InnerText;
                        if (lvDados.Items.Cast<ListViewItem>().Any(existingItem => existingItem.Text == produto))
                        {
                            skipItem = true;
                        }

                        if (skipItem)
                        {
                            continue;
                        }

                        string ncm = prodNode["NCM"]?.InnerText;
                        string unidade = prodNode["uCom"]?.InnerText;
                        string preco = prodNode["vUnCom"]?.InnerText;

                        ListViewItem newItem = new ListViewItem(produto);
                        newItem.SubItems.Add(ncm);
                        newItem.SubItems.Add(unidade);
                        newItem.SubItems.Add(preco);

                        // Processar o CST específico para este produto
                        XmlNode cstNode = impostoNode.SelectSingleNode(".//nfe:ICMS/*/nfe:CST", nsmgr);
                        string codigoTributacao = cstNode?.InnerText ?? "N/A";

                        string cstName = cstNames.ContainsKey(codigoTributacao) ? cstNames[codigoTributacao] : codigoTributacao;
                        newItem.SubItems.Add(cstName);

                        XmlNode cstSaida = impostoNode.SelectSingleNode("//nfe:PIS/*/nfe:CST", nsmgr);
                        string cstSaida1 = cstSaida?.InnerText ?? "Não Encontrado: Padrão para incluir CST 01";
                        string cstSaidaName = cstSaidaNames.ContainsKey(cstSaida1) ? cstSaidaNames[cstSaida1] : cstSaida1;
                        newItem.SubItems.Add(cstSaidaName);


                        XmlNode codigoAnp = prodNode.SelectSingleNode(".//nfe:comb/nfe:cProdANP", nsmgr);
                        string codigoAnp1 = codigoAnp?.InnerText;
                        newItem.SubItems.Add(codigoAnp1);

                        string cest = prodNode["CEST"]?.InnerText;
                        newItem.SubItems.Add(cest);

                        lvDados.Items.Add(newItem);

                        contadorProdutos++;
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

        private void LerArquivoXmlNFe(string xmlArquivo)
        {
            try
            {
                string[] palavrasChaveCombustivel = { "COMBUSTÍVEL", "GASOLINA", "ETANOL", "DIESEL", "GNV", "BS500", "S500", "S10", "ALCOOL" };

                Dictionary<string, string> cstNames = new Dictionary<string, string>
                {
                    {"00", "00 - Produto Tributado"},
                    {"10", "10 - Substituição tributária"},
                    {"20", "20 - Redução de base de cálculo"},
                    {"30", "30 - Não incidência"},
                    {"40", "40 - Produto Isento"},
                    {"41", "41 - Produto Isento"},
                    {"50", "50 - Não incidência"},
                    {"51", "51 - Não incidência"},
                    {"60", "60 - Substituição tributária"},
                    {"61", "61 - Monofásica"},
                    {"70", "70 - Redução de base de cálculo"},
                    {"90", "90 - Não incidência"},
                };

                Dictionary<string, string> cstSaidaNames = new Dictionary<string, string>
                {
                    {"01", "01 - OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA BÁSICA"},
                    {"02", "02 - OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA DIFERENCIADA"},
                    {"04", "04 - OPERAÇÃO TRIBUTÁVEL MONOFÁSICA - REVENDA A ALÍQUOTA ZERO"},
                    {"05", "05 - OPERAÇÃO TRIBUTÁVEL POR SUBSTITUIÇÃO TRIBUTÁRIA"},
                    {"06", "06 - OPERAÇÃO TRIBUTÁVEL A ALÍQUOTA ZERO"},
                    {"07", "07 - OPERAÇÃO ISENTA DA CONTRIBUIÇÃO"},
                    {"08", "08 - OPERACAO SEM INCIDENCIA DA CONTRIBUICÃO"},
                    {"49", "49 - OUTRAS OPERAÇÕES DE SAÍDA"},
                    {"99", "99 - OUTRAS OPERAÇÕES"},
                };

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlArquivo);

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                nsmgr.AddNamespace("nfe", "http://www.portalfiscal.inf.br/nfe");

                XmlElement root = xmlDoc.DocumentElement;
                Action processXmlNode = () => 
                {
                    foreach (XmlNode node in root.SelectNodes("//nfe:det", nsmgr))
                    {
                        XmlNode prodNode = node.SelectSingleNode("nfe:prod", nsmgr);
                        XmlNode impostoNode = node.SelectSingleNode("nfe:imposto", nsmgr);

                        bool skipItem = false;

                        foreach (XmlNode childNode in prodNode.ChildNodes)
                        {
                            foreach (string palavra in palavrasChaveCombustivel)
                            {
                                if (childNode.InnerText.Contains(palavra))
                                {
                                    skipItem = true;
                                    break;
                                }
                            }
                            if (skipItem)
                            {
                                break;
                            }
                        }

                        string produto = prodNode["xProd"]?.InnerText;
                        if (lvDados.Items.Cast<ListViewItem>().Any(existingItem => existingItem.Text == produto))
                        {
                            skipItem = true;
                        }

                        if (skipItem)
                        {
                            continue;
                        }

                        string ncm = prodNode["NCM"]?.InnerText;
                        string unidade = prodNode["uCom"]?.InnerText;
                        string preco = prodNode["vUnCom"]?.InnerText;

                        ListViewItem newItem = new ListViewItem(produto);
                        newItem.SubItems.Add(ncm);
                        newItem.SubItems.Add(unidade);
                        newItem.SubItems.Add(preco);

                        // Processar o CST específico para este produto
                        XmlNode cstNode = impostoNode.SelectSingleNode(".//nfe:ICMS/*/nfe:CST", nsmgr);
                        string codigoTributacao = cstNode?.InnerText ?? "N/A";

                        string cstName = cstNames.ContainsKey(codigoTributacao) ? cstNames[codigoTributacao] : codigoTributacao;
                        newItem.SubItems.Add(cstName);

                        XmlNode cstSaida = impostoNode.SelectSingleNode(".//nfe:PIS/*/nfe:CST", nsmgr);
                        string cstSaida1 = cstSaida?.InnerText ?? "Não Encontrado: Padrão para incluir CST 01";
                        string cstSaidaName = cstSaidaNames.ContainsKey(cstSaida1) ? cstSaidaNames[cstSaida1] : cstSaida1;
                        newItem.SubItems.Add(cstSaidaName);

                        XmlNode codigoAnp = prodNode.SelectSingleNode(".//nfe:comb/nfe:cProdANP", nsmgr);
                        string codigoAnp1 = codigoAnp?.InnerText;
                        newItem.SubItems.Add(codigoAnp1);

                        string cest = prodNode["CEST"]?.InnerText;
                        newItem.SubItems.Add(cest);

                        lvDados.Items.Add(newItem);

                        contadorProdutos++;
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
        private int MapearCodigoTributacao(string cst)
        {
            switch (cst)
            {
                case "00 - Produto Tributado":
                    return 1;  // PRODUTO TRIBUTADO
                case "10 - Substituição tributária":
                case "60 - Substituição tributária":
                    return 2;  // SUBST. TRIBUTÁRIA
                case "40 - Produto Isento":
                case "41 - Produto Isento":
                    return 3;  // PRODUTO ISENTO
                case "30 - Não incidência":
                case "50 - Não incidência":
                case "51 - Não incidência":
                case "90 - Não incidência":
                    return 4;  // NÃO INCIDÊNCIA
                case "20 - Redução de base de cálculo":
                case "70 - Redução de base de cálculo":
                    return 5;  // REDUÇÃO BASE CÁLCULO
                case "61 - Monofásica":
                    return 6;
                default:
                    throw new ArgumentException($"Código CST '{cst}' não reconhecido.");
            }
        }
        private int MapearCodigoUnidade(string unidade)
        {
            switch (unidade)
            {
                case "CX":
                case "Cx":
                case "cx":
                case "PC":
                case "pc":
                case "Pc":
                case "SC":
                case "sc":
                case "Sc":
                case "CXA":
                case "Cxa":
                case "cxa":
                    return 1;
                case "DUZ":
                    return 2;
                case "KG":
                case "Kg":
                case "kg":
                    return 3;
                case "LT":
                case "Lt":
                case "lt":
                case "L":
                case "l":
                    return 4;
                case "M3":
                case "m3":
                    return 5;
                case "MT":
                case "Mt":
                case "mt":
                    return 6;
                case "UN":
                case "Un":
                case "un":
                case "EV":
                case "Ev":
                case "ev":
                    return 7;
                default:
                    return 7;
            }
        }
        private int MapearCodigoCst(string cst)
        {
            switch (cst)
            {
                case "01 - OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA BÁSICA":
                case "Não Encontrado: Padrão para incluir CST 01":
                    return 1;
                case "04 - OPERAÇÃO TRIBUTÁVEL MONOFÁSICA - REVENDA A ALÍQUOTA ZERO":
                    return 2;
                case "05 - OPERAÇÃO TRIBUTÁVEL POR SUBSTITUIÇÃO TRIBUTÁRIA":
                    return 3;
                case "06 - OPERAÇÃO TRIBUTÁVEL A ALÍQUOTA ZERO":
                    return 4;
                case "07 - OPERAÇÃO ISENTA DA CONTRIBUIÇÃO":
                    return 5;
                case "08 - OPERACAO SEM INCIDENCIA DA CONTRIBUICÃO":
                    return 6;
                case "49 - OUTRAS OPERAÇÕES DE SAÍDA":
                    return 7;
                case "99 - OUTRAS OPERAÇÕES":
                    return 8;
                case "02 - OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA DIFERENCIADA":
                    return 9;
                default:
                    throw new ArgumentException($"Código não reconhecido.");
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
            try
            {
                using (FbConnection conn = new FbConnection(banco.ConnectionString))
                {
                    conn.Open();
                    using (FbTransaction transaction = conn.BeginTransaction())
                    {
                        bool hasErrors = false;

                        // Verificar se produto_nivel1 já existe
                        string descricaoNivel1 = "PRODUTOS IMPORTADOS";
                        string selectProdutoNivel1 = "SELECT produto_nivel1_id FROM produto_nivel1 WHERE descricao = @descricao";
                        int produtoNivel1Id;

                        using (FbCommand cmd = new FbCommand(selectProdutoNivel1, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@descricao", descricaoNivel1);
                            object result = cmd.ExecuteScalar();

                            if (result != null)
                            {
                                produtoNivel1Id = Convert.ToInt32(result);
                            }
                            else
                            {
                                // Inserir em produto_nivel1 se não existir
                                string insertProdutoNivel1 = "INSERT INTO produto_nivel1 (descricao) VALUES (@descricao) RETURNING produto_nivel1_id";
                                using (FbCommand insertCmd = new FbCommand(insertProdutoNivel1, conn, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@descricao", descricaoNivel1);
                                    produtoNivel1Id = Convert.ToInt32(insertCmd.ExecuteScalar());
                                }
                            }
                        }

                        // Verificar se produto_nivel2 já existe
                        string descricaoNivel2 = "Produtos Importados";
                        string selectProdutoNivel2 = "SELECT produto_nivel2_id FROM produto_nivel2 WHERE produto_nivel1_id = @produtoNivel1Id AND descricao = @descricao";
                        int produtoNivel2Id;

                        using (FbCommand cmd = new FbCommand(selectProdutoNivel2, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@produtoNivel1Id", produtoNivel1Id);
                            cmd.Parameters.AddWithValue("@descricao", descricaoNivel2);
                            object result = cmd.ExecuteScalar();

                            if (result != null)
                            {
                                produtoNivel2Id = Convert.ToInt32(result);
                            }
                            else
                            {
                                string insertProdutoNivel2 = "INSERT INTO produto_nivel2 (produto_nivel1_id, descricao) VALUES (@produtoNivel1Id, @descricao) RETURNING produto_nivel2_id";
                                using (FbCommand insertCmd = new FbCommand(insertProdutoNivel2, conn, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@produtoNivel1Id", produtoNivel1Id);
                                    insertCmd.Parameters.AddWithValue("@descricao", descricaoNivel2);
                                    produtoNivel2Id = Convert.ToInt32(insertCmd.ExecuteScalar());
                                }
                            }
                        }

                        foreach (ListViewItem item in lvDados.Items)
                        {
                            try
                            {
                                string nomeProduto = TruncarTexto(item.SubItems[0].Text, 40);
                                string ncm = item.SubItems[1].Text;
                                string uCom = item.SubItems[2].Text;
                                string preco = item.SubItems[3].Text;
                                string cst = item.SubItems[4].Text;
                                string cstSaida = item.SubItems[5].Text;
                                string anp = item.SubItems[6].Text;
                                string cest = item.SubItems[7].Text;

                                int codigoTributacao = MapearCodigoTributacao(cst);
                                int unidadePosto = MapearCodigoUnidade(uCom);
                                int cstSaida1 = MapearCodigoCst(cstSaida);

                                ultimoProdutoId = ObterUltimoProdutoId(conn, transaction);

                                // Verificar se o produto já existe pelo nome
                                string selectProduto = "SELECT COUNT(*) FROM PRODUTO WHERE DESCRICAO = @nomeProduto";
                                using (FbCommand cmd = new FbCommand(selectProduto, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@nomeProduto", nomeProduto);
                                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                                    if (count > 0)
                                    {
                                        continue;
                                    }
                                }

                                string insertProduto = "INSERT INTO PRODUTO (PRODUTO_ID, PRODUTO_NIVEL2_ID, DESCRICAO, CT, CST_PIS_COFINS, " +
                                    "CODIGO_NCM, UND_COMERCIAL_COMPRA, UND_TRIB_COMPRA, UND_TRIB_VENDA, UND_COMERCIAL_VENDA, CODIGO_ANP, codigo_cest) VALUES " +
                                    "(@codigo, @produtoNivel2Id, @nomeProduto, @codigoTributacao, @cstSaida, @ncm, @undCompra, @undTribCompra, " +
                                    "@undTribVenda, @undVenda, @anp, @codigo_cest)";

                                using (FbCommand cmd = new FbCommand(insertProduto, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@codigo", ultimoProdutoId + 1);
                                    cmd.Parameters.AddWithValue("@produtoNivel2Id", produtoNivel2Id);
                                    cmd.Parameters.AddWithValue("@nomeProduto", nomeProduto);
                                    cmd.Parameters.AddWithValue("@codigoTributacao", codigoTributacao);
                                    cmd.Parameters.AddWithValue("@ncm", ncm);
                                    cmd.Parameters.AddWithValue("@undCompra", unidadePosto);
                                    cmd.Parameters.AddWithValue("@undTribCompra", unidadePosto);
                                    cmd.Parameters.AddWithValue("@undTribVenda", unidadePosto);
                                    cmd.Parameters.AddWithValue("@undVenda", unidadePosto);
                                    cmd.Parameters.AddWithValue("@cstSaida", cstSaida1);
                                    cmd.Parameters.AddWithValue("@anp", string.IsNullOrEmpty(anp) ? (object)DBNull.Value : anp);
                                    cmd.Parameters.AddWithValue("@codigo_cest", string.IsNullOrEmpty(cest) ? (object)DBNull.Value : cest);
                                    cmd.ExecuteNonQuery();
                                }

                                string insertProdutoEmpresa = "INSERT INTO PRODUTO_EMPRESA (PRODUTO_ID, PRC_VEN_VISTA, Empresa_id) VALUES (@codigo, @preco,@empresa_Id)";

                                using (FbCommand cmd = new FbCommand(insertProdutoEmpresa, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@empresa_id", cbEmpresa.SelectedValue);
                                    cmd.Parameters.AddWithValue("@codigo", ultimoProdutoId + 1); // Mesmo produto_id
                                    cmd.Parameters.AddWithValue("@preco", Convert.ToDecimal(preco, CultureInfo.InvariantCulture));
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao importar dados do item '{item.Text}': {ex.Message}");
                                hasErrors = true;
                            }
                        }

                        if (!hasErrors)
                        {
                            transaction.Commit();
                            MessageBox.Show("Dados importados com sucesso!");
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("Importação abortada devido a erros.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: Necessário configurar Banco de Dados");
            }
        }

        private int ObterUltimoProdutoId(FbConnection conn, FbTransaction transaction)
        {
            int ultimoId = 0;
            string query = "SELECT MAX(PRODUTO_ID) FROM PRODUTO";

            using (FbCommand cmd = new FbCommand(query, conn, transaction))
            {
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    ultimoId = Convert.ToInt32(result);
                }
            }

            return ultimoId;
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

        private void ImportarParametroProduto() 
        {
            try 
            {
                using (FbConnection conn = new FbConnection(banco.ConnectionString))
                {
                    conn.Open();
                    FbTransaction transaction = conn.BeginTransaction();

                    string insertParametroProduto58 = "insert into PRM_ATR_LOGICO_PRODUTO (EMPRESA_ID, PRODUTO_ID, PRM_ATR_LOGICO_ID, VALOR) select PR.EMPRESA_ID, PR.PRODUTO_ID, '58', 'S' from produto_empresa PR where not exists(select 0 from PRM_ATR_LOGICO_PRODUTO PALP where PALP.PRODUTO_ID = PR.PRODUTO_ID and PALP.PRM_ATR_LOGICO_ID = 58) and PR.EMPRESA_ID = @EMPRESA_ID and PR.PRODUTO_ID in (select P.PRODUTO_ID from produto P);";
                    using (FbCommand cmd = new FbCommand(insertParametroProduto58, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@empresa_id", cbEmpresa.SelectedValue);
                        cmd.ExecuteNonQuery();

                    }

                    string insertParametroProduto60 = "insert into PRM_ATR_LOGICO_PRODUTO (EMPRESA_ID, PRODUTO_ID, PRM_ATR_LOGICO_ID, VALOR) select PR.EMPRESA_ID, PR.PRODUTO_ID, '60', 'S' from produto_empresa PR where not exists(select 0 from PRM_ATR_LOGICO_PRODUTO PALP where PALP.PRODUTO_ID = PR.PRODUTO_ID and PALP.PRM_ATR_LOGICO_ID = 60) and PR.EMPRESA_ID = @EMPRESA_ID and PR.PRODUTO_ID in (select P.PRODUTO_ID from produto P);";
                    using (FbCommand cmd = new FbCommand(insertParametroProduto60, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@empresa_id", cbEmpresa.SelectedValue);
                        cmd.ExecuteNonQuery();

                    }

                    string insertParametroProduto65 = "insert into PRM_ATR_LOGICO_PRODUTO (EMPRESA_ID, PRODUTO_ID, PRM_ATR_LOGICO_ID, VALOR) select PR.EMPRESA_ID, PR.PRODUTO_ID, '65', 'S' from produto_empresa PR where not exists(select 0 from PRM_ATR_LOGICO_PRODUTO PALP where PALP.PRODUTO_ID = PR.PRODUTO_ID and PALP.PRM_ATR_LOGICO_ID = 65) and PR.EMPRESA_ID = @EMPRESA_ID and PR.PRODUTO_ID in (select P.PRODUTO_ID from produto P);";
                    using (FbCommand cmd = new FbCommand(insertParametroProduto65, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@empresa_id", cbEmpresa.SelectedValue);
                        cmd.ExecuteNonQuery();

                    }

                    string insertParametroCstSubstituicaoTributaria = "UPDATE produto pp SET pp.cst_pis_cofins_entrada = 32 WHERE pp.ct = 2 AND pp.produto_nivel2_id IN (SELECT p2.produto_nivel2_id FROM produto_nivel2 p2 WHERE p2.descricao = 'Produtos Importados');";
                    using (FbCommand cmd = new FbCommand(insertParametroCstSubstituicaoTributaria, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();

                    }

                    string insertParametroCst = "UPDATE produto pp SET pp.cst_pis_cofins_entrada = 33 WHERE pp.ct != 2 AND pp.produto_nivel2_id IN (SELECT p2.produto_nivel2_id FROM produto_nivel2 p2 WHERE p2.descricao = 'Produtos Importados');";
                    using (FbCommand cmd = new FbCommand(insertParametroCst, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();

                    }

                    string insertParametroDataTurno = "UPDATE produto_empresa pe SET pe.cfwin_data_vigencia = CURRENT_DATE, pe.cfwin_turno_id_vigencia = 1 where pe.empresa_id = @empresa_id and pe.cfwin_data_vigencia is null and pe.cfwin_turno_id_vigencia is null";
                    using (FbCommand cmd = new FbCommand(insertParametroDataTurno, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@empresa_id", cbEmpresa.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }

                    string insertParametroPrecoCusto = "update PRODUTO_EMPRESA PE set PE.PRC_CUSTO = PE.PRC_VEN_VISTA * 0.70 where PE.empresa_id = @empresa_id and PE.PRC_CUSTO = 0 and PE.PRODUTO_ID in (select PP.PRODUTO_ID from PRODUTO PP left join PRODUTO_NIVEL2 P2 on PP.PRODUTO_NIVEL2_ID = P2.PRODUTO_NIVEL2_ID where P2.DESCRICAO = 'Produtos Importados')";
                    using (FbCommand cmd = new FbCommand(insertParametroPrecoCusto, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@empresa_id", cbEmpresa.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();

                }
            }
            catch(Exception) 
            {
            }
            
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
                    txtEncontrado.Text = totalArquivos.ToString();
                    txtProduto.Text = contadorProdutos.ToString();
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

        private void btnSelecionar_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                {
                    pastaXml = folderBrowserDialog.SelectedPath;
                    MessageBox.Show("Pasta selecionada: " + pastaXml);
                    txtDiretorio.Text = pastaXml;
                    
                    string[] arquivosXml = Directory.GetFiles(pastaXml, "*.xml", SearchOption.AllDirectories);

                }
            }
        }
        private void btnImportar_Click_1(object sender, EventArgs e)
        {
            ImportarDados();
            lvDados.Items.Clear();
            txtProduto.Text = "";
            txtDiretorio.Text = "";
            txtEncontrado.Text = "";
            btnImportar.Enabled = false;
            ImportarParametroProduto();
        }


    }
}

