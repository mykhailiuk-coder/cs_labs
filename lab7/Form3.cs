using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form3 : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private Random rnd = new Random();
        private Color selectedColor = Color.Black; 
        public Form3()
        {
            InitializeComponent();

            comboBoxType.Items.Clear();
            comboBoxType.Items.AddRange(new string[] { "Шестикутник", "Ромб", "Трикутник", "Дуга" });
            comboBoxType.SelectedIndex = 0;

            pictureBox1.Paint += pictureBox1_Paint;

            this.DoubleBuffered = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Width <= 100 || pictureBox1.Height <= 100) return;

            int size = (int)numSize.Value;
            Color color = selectedColor;

            int x = rnd.Next(size, pictureBox1.Width - size);
            int y = rnd.Next(size, pictureBox1.Height - size);

            Shape newShape;

            switch (comboBoxType.SelectedIndex)
            {
                case 0: newShape = new Hexagon(x, y, size, color); break;
                case 1: newShape = new Rhombus(x, y, size, color); break;
                case 2: newShape = new Triangle(x, y, size, color); break;
                default: newShape = new MyArc(x, y, size, color); break;
            }

            shapes.Add(newShape);

            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();

            colorDlg.FullOpen = true;

            colorDlg.Color = selectedColor;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDlg.Color;
            }
        }
    }

    public abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color ShapeColor { get; set; }
        public int Size { get; set; }

        public Shape(int x, int y, int size, Color color)
        {
            X = x; Y = y; Size = size; ShapeColor = color;
        }

        public abstract void Draw(Graphics g);
    }

    public class Rhombus : Shape
    {
        public Rhombus(int x, int y, int size, Color color) : base(x, y, size, color) { }

        public override void Draw(Graphics g)
        {
            Point[] points = {
            new Point(X, Y - Size),         
            new Point(X + Size, Y),         
            new Point(X, Y + Size),         
            new Point(X - Size, Y)          
        };
            g.FillPolygon(new SolidBrush(ShapeColor), points);
        }
    }

    public class Hexagon : Shape
    {
        public Hexagon(int x, int y, int size, Color color) : base(x, y, size, color) { }

        public override void Draw(Graphics g)
        {
            Point[] points = new Point[6];
            for (int i = 0; i < 6; i++)
            {
                double angle = Math.PI / 3 * i;
                points[i] = new Point(
                    (int)(X + Size * Math.Cos(angle)),
                    (int)(Y + Size * Math.Sin(angle))
                );
            }
            g.FillPolygon(new SolidBrush(ShapeColor), points);
        }
    }

    public class Triangle : Shape
    {
        public Triangle(int x, int y, int size, Color color) : base(x, y, size, color) { }

        public override void Draw(Graphics g)
        {
            Point[] points = {
            new Point(X, Y - Size),
            new Point(X - Size, Y + Size),
            new Point(X + Size, Y + Size)
        };
            g.FillPolygon(new SolidBrush(ShapeColor), points);
        }
    }

    public class MyArc : Shape
    {
        public MyArc(int x, int y, int size, Color color) : base(x, y, size, color) { }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(ShapeColor, 3);
            g.DrawArc(pen, X, Y, Size, Size, 0, 180); 
        }
    }
}
