using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PortaFacil
{
    internal class personalizacao
    {
        public static class IconManager
        {
            // Método para redimensionar uma imagem mantendo a proporção
            private static Image ResizeImage(Image image, int width, int height)
            {
                int sourceWidth = image.Width;
                int sourceHeight = image.Height;
                float aspectRatio = (float)sourceWidth / sourceHeight;

                int destWidth, destHeight;
                if (aspectRatio > 1)
                {
                    destWidth = width;
                    destHeight = (int)(width / aspectRatio);
                }
                else
                {
                    destWidth = (int)(height * aspectRatio);
                    destHeight = height;
                }

                var destImage = new Bitmap(destWidth, destHeight);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    graphics.DrawImage(image, new Rectangle(0, 0, destWidth, destHeight));
                }

                return destImage;
            }

            // Método para definir imagem redimensionada, alinhamento e cores em um botão
            public static void SetButtonIcon(Button button, Image image, int width, int height, ContentAlignment alignment, Color backColor, Color foreColor)
            {
                Image resizedImage = ResizeImage(image, width, height);
                button.Image = resizedImage;
                button.ImageAlign = alignment;
                button.BackColor = backColor;
                button.ForeColor = foreColor;
            }

            public static void SetPicturebox(PictureBox pictureBox, Image image, int width, int height, Color backColor, Color foreColor)
            {
                Image resizedImage = ResizeImage(image, width, height);
                pictureBox.Image = resizedImage;
                pictureBox.BackColor = backColor;
                pictureBox.ForeColor = foreColor;
            }

            // Método para definir imagem em um ToolStripButton
            public static void SetToolStripButtonIcon(ToolStripButton toolStripButton, Image image)
            {
                toolStripButton.Image = image;
            }

            // Método para definir ícone em um NotifyIcon
            public static void SetNotifyIcon(NotifyIcon notifyIcon, Icon icon)
            {
                notifyIcon.Icon = icon;
            }

        }
    }
}
