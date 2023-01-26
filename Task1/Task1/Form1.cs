using static Task1.Form1;
using System.Drawing;
using System.Windows.Forms;
using System;
using Timer = System.Threading.Timer;

namespace Task1
{
    public partial class Form1 : Form
    {
        public class Circle
        {
            public Point Center { get; set; }
            public int Radius { get; set; }
            public Circle(Point point, int radius)
            {
                Center = point;
                Radius = radius;
            }
        }

        private Timer _timer;
        Point cursor;
        List<Circle> circles = new List<Circle>();
        List<Circle> circlesDelete = new List<Circle>();
        int num = 0;
        int radius = 0;
        SolidBrush color;

        public Form1()
        {
            InitializeComponent();
            QuantityLabel.Text = "0";
            SpeedTextBox.Text = "100";
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
    
            if (e.Button == MouseButtons.Left)
            {
                if (e.Button == MouseButtons.Left)
                {
                    cursor = new Point(e.X, e.Y);
                    Circle circle = new Circle(cursor, radius);
                    circles.Add(circle);
                    if (circles.Count == 1)
                    {
                        TimerCallback tm = new TimerCallback(Draw);
                        _timer = new Timer(tm, num, 0, 5);
                    }             
                    Random random = new Random();
                    SolidBrush pen = new SolidBrush(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
                    color = pen;

                }

            }
        }
        public void Draw(object obj)
        {

        }
    }
}