using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            pictureBoxMain.MouseDown += PictureBoxMain_MouseDown;
            pictureBoxMain.MouseMove += PictureBoxMain_MouseMove;
        }

        private void PickColor(int x, int y)
        {
            if (pictureBoxMain.Image == null) return;

            try
            {
                Bitmap bmp = new Bitmap(pictureBoxMain.Image);

                if (x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
                {
                    Color pixelColor = bmp.GetPixel(x, y);

                    pictureBoxColorSample.BackColor = pixelColor;

                    lblR.Text = $"R: {pixelColor.R}";
                    lblG.Text = $"G: {pixelColor.G}";
                    lblB.Text = $"B: {pixelColor.B}";
                }

                bmp.Dispose(); 
            }
            catch { }
        }

        private void PictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) PickColor(e.X, e.Y);
        }

        private void PictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) PickColor(e.X, e.Y);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images|*.jpg;*.png;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxMain.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBoxColorSample.BackColor == Color.Transparent) return;

            saveFileDialog1.Filter = "Bitmap Image|*.bmp|PNG Image|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap saveBmp = new Bitmap(100, 100);
                using (Graphics g = Graphics.FromImage(saveBmp))
                {
                    g.Clear(pictureBoxColorSample.BackColor);
                }
                saveBmp.Save(saveFileDialog1.FileName);
            }
        }
    }
}
