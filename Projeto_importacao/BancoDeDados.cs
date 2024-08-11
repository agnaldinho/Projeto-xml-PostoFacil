using FirebirdSql.Data.FirebirdClient;
using System;
using System.Net;
using System.Windows.Forms;

namespace PortaFacil
{
    public partial class BancoDeDados : Form
    {
        private string connectionString;
        private string caminhoBancoDadosSelecionado;
        public BancoDeDados()
        {
            InitializeComponent();
            txtSenha.UseSystemPasswordChar = true;
            txtIp.Text = LastServerAddress;
            txtUsuario.Text = LastUser;
            txtPorta.Text = LastPort;
            txtSenha.Text = LastPassword;
            txtBanco.Text = LastCaminho;
            txtDiretorio.Text = LastDiretorio;

        }

        private void btnSelecionarArquivo_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Banco de Dados (*.fdb)|*.fdb|Todos os Arquivos (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                caminhoBancoDadosSelecionado = openFileDialog.FileName;
                string nomeBancoDados = System.IO.Path.GetFileNameWithoutExtension(caminhoBancoDadosSelecionado);
                txtBanco.Text = nomeBancoDados;

                LastServerAddress = Dns.GetHostName();
                LastUser = "SYSDBA";
                LastPort = "3050";
                LastPassword = "masterkey";
                LastDiretorio = caminhoBancoDadosSelecionado;

                txtIp.Text = LastServerAddress;
                txtUsuario.Text = LastUser;
                txtPorta.Text = LastPort;
                txtSenha.Text = LastPassword;
                txtDiretorio.Text = LastDiretorio;
            }
        }
        public static string SavedConnectionString { get; private set; }
        public void ConfigurarConnectionString()
        {
            string serverAddress = txtIp.Text;
            string user = txtUsuario.Text;
            string password = txtSenha.Text;
            int portNumber;
            int.TryParse(txtPorta.Text, out portNumber);

            connectionString =
                $"User={user};" +
                $"Password={password};" +
                $"Database={caminhoBancoDadosSelecionado};" +
                $"DataSource={serverAddress};" +
                $"Port={portNumber};" +
                $"Dialect=3;";
        }

        public static string LastServerAddress { get; set; }
        public static string LastUser { get; set; }
        public static string LastPort { get; set; }
        public static string LastPassword { get; set; }
        public static string LastCaminho { get; set; }
        public static string LastDiretorio { get; set; }
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        private void btnSalvar_Click_1(object sender, EventArgs e)
        {

            ConfigurarConnectionString();

            if (string.IsNullOrEmpty(caminhoBancoDadosSelecionado))
            {
                MessageBox.Show("Selecione um arquivo de banco de dados.");
                return;
            }

            SavedConnectionString = connectionString;

            LastServerAddress = txtIp.Text;
            LastUser = txtUsuario.Text;
            LastPort = txtPorta.Text;
            LastPassword = txtSenha.Text;
            LastCaminho = txtBanco.Text;
            LastDiretorio = txtDiretorio.Text;

            txtBanco.ReadOnly = true;
            try 
            {
                var connection = new FbConnection(connectionString);
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexão com o banco de dados estabelecida com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao configurar o banco de dados " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione um arquivo de banco de dados.");
            }
                
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            txtIp.Text = "";
            txtBanco.Text = "";
            txtPorta.Text = "";
            txtSenha.Text = "";
            txtUsuario.Text = "";
            txtDiretorio.Text = "";
        }
    }
}
