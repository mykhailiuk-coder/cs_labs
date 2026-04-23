using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        private double angle = 0; 
        private int radius = 100; 
        private Random rnd = new Random();
        private Pen drawingPen = new Pen(Color.Black, 2);

        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 50; 
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            this.DoubleBuffered = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int centerX = centerButton.Location.X + centerButton.Width / 2;
            int centerY = centerButton.Location.Y + centerButton.Height / 2;

            angle += 0.1;

            int newX = (int)(centerX + radius * Math.Cos(angle)) - (rotatingPanel.Width / 2);
            int newY = (int)(centerY + radius * Math.Sin(angle)) - (rotatingPanel.Height / 2);

            rotatingPanel.Location = new Point(newX, newY);

            drawingPen.Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            drawingPen.Width = rnd.Next(1, 10);

            rotatingPanel.Invalidate();
            this.Invalidate(); 
        }

        private void rotatingPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(drawingPen, 5, 5, rotatingPanel.Width - 10, rotatingPanel.Height - 10);
        }
    }
}
