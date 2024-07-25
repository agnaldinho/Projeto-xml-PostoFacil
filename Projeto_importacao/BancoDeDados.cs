using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PortaFacil.personalizacao;

namespace PortaFacil
{
    public partial class BancoDeDados : Form
    {
        private string connectionString;
        private string caminhoBancoDadosSelecionado;
        public BancoDeDados()
        {
            InitializeComponent();
            personalizarbotao();
            txtSenha.UseSystemPasswordChar = true;
            txtIp.Text = LastServerAddress;
            txtUsuario.Text = LastUser;
            txtPorta.Text = LastPort;
            txtSenha.Text = LastPassword;
            txtBanco.Text = LastCaminho;
            txtDiretorio.Text = LastDiretorio;

        }
        private void personalizarbotao()
        {
            Color corRoxo = Color.FromArgb(0x28, 0x0A, 0x3C);
            IconManager.SetButtonIcon(btnSelecionarArquivo, Properties.Resources.BancoDeDados, 32, 32, ContentAlignment.BottomLeft, Color.Indigo, Color.White);
            IconManager.SetButtonIcon(btnExcluir, Properties.Resources.excluir, 32, 32, ContentAlignment.BottomLeft, Color.Indigo, Color.White);
            IconManager.SetButtonIcon(btnSalvar, Properties.Resources.save, 32, 32, ContentAlignment.BottomLeft, Color.Indigo, Color.White);

        }

        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
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

        public FbConnection AbrirConexao()
        {
            var connection = new FbConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (FbException e)
            {
                MessageBox.Show("Erro ao configurar o banco de dados " + e.Message);
            }

            return connection;
        }

        public FbConnection AbrirConexaoBanco()
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

            return connection;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            txtIp.Text = "";
            txtBanco.Text = "";
            txtPorta.Text = "";
            txtSenha.Text = "";
            txtUsuario.Text = "";
            txtDiretorio.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
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
            AbrirConexaoBanco();
        }
    }
}
