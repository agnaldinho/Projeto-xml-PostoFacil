using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static PortaFacil.personalizacao;

namespace PortaFacil
{
    public partial class Home : Form
    {

        public Home()
        {
            InitializeComponent();
            personalizarbotao();
            ImportarClient cliente = new ImportarClient();
            Hub(cliente);
            
        }

        private void Hub(Form formularioParaMostrar) 
        {
            panel2.Controls.Clear();

            formularioParaMostrar.TopLevel = false;
            formularioParaMostrar.FormBorderStyle = FormBorderStyle.None;
            formularioParaMostrar.Dock = DockStyle.Fill;
            panel2.Controls.Add(formularioParaMostrar);
            formularioParaMostrar.Show();
        }
        private void personalizarbotao() 
        {
            Color corRoxo = Color.FromArgb(0x28, 0x0A, 0x3C);      
            IconManager.SetPicturebox(pbLogo, Properties.Resources.xmlLogo, 150, 150, corRoxo, corRoxo);
            IconManager.SetPicturebox(pbLinx, Properties.Resources.Linx, 150, 150, Color.Indigo, Color.Indigo);

        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private void PnMexer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void pnMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pnlogo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void pbLogo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnCliente_Click_1(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ImportarClient cliente = new ImportarClient();
            Hub(cliente);
        }
        private void btnBanco_Click_1(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            BancoDeDados banco = new BancoDeDados();
            Hub(banco);
        }

        private void btnProduto_Click_1(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ImportarProduto produto = new ImportarProduto();
            Hub(produto);
        }

        private void btnSobre_Click_1(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Sobre sobre = new Sobre();
            Hub(sobre);
        }


    }
}
