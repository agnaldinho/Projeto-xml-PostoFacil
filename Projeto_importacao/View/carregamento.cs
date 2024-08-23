using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortaFacil
{
    public partial class carregamento : Form
    {

        public carregamento()
        {
            InitializeComponent();
            MostrarGIFAnimado();
            this.BackColor = Color.White;
            this.TransparencyKey = Color.Transparent;
            this.FormBorderStyle = FormBorderStyle.None;

        }

        private void MostrarGIFAnimado()
        {
            Image gifImage = Properties.Resources.AguardarProgresso;

            pictureBox1.Image = gifImage;


            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public void AtualizarProgresso(int progresso)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action<int>(AtualizarProgresso), progresso);
            }
            else
            {
                progressBar1.Value = progresso;
                //label2.Text = progresso.ToString() + "%";
            }
        }
    }
}
