using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PortaFacil.personalizacao;

namespace PortaFacil
{
    public partial class Sobre : Form
    {
        public Sobre()
        {
            InitializeComponent();
            Color corRoxo = Color.FromArgb(0x28, 0x0A, 0x3C);
            IconManager.SetPicturebox(pbLinkedin, Properties.Resources.linkedin, 50, 50, corRoxo,corRoxo);
            IconManager.SetPicturebox(pbLinkedin2, Properties.Resources.linkedin, 50, 50, corRoxo, corRoxo);
            IconManager.SetPicturebox(pbSamuel, Properties.Resources.linkedin, 50, 50, corRoxo, corRoxo);
            IconManager.SetPicturebox(pbGit, Properties.Resources.git, 50, 50, corRoxo, corRoxo);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.linkedin.com/in/agnaldo-pereira-da-silva-junior-2b08181a2/";

            System.Diagnostics.Process.Start(url);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/agnaldinho";

            System.Diagnostics.Process.Start(url);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.linkedin.com/in/danilo-muniz-ribeiro/";

            System.Diagnostics.Process.Start(url);

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.linkedin.com/in/samuelmrp/";

            System.Diagnostics.Process.Start(url);
        }
    }
}
