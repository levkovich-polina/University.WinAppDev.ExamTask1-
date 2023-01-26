using System.Drawing;
using Timer = System.Threading.Timer;

namespace Task1
{
    public partial class Form1 : Form
    {
        public class Circle
        {
            public Point Center { get; set; }
            public int Radius { get; set; }
            public SolidBrush Brush { get; set; }
            public Circle(Point point, int radius, SolidBrush brush)
            {
                Center = point;
                Radius = radius;
                Brush = brush;
            }
        }

        private Timer _timer;
        List<Circle> _circles = new List<Circle>();
      


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
                Random random = new Random();
                SolidBrush brush = new SolidBrush(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
                Circle circle = new Circle(e.Location, 0, brush);
                _circles.Add(circle);
                if (_circles.Count == 1)
                {
                    TimerCallback tm = new TimerCallback(OnTimerTicked);
                    _timer = new Timer(tm, 0, 0, 5);
                }

            }
        }
        public void OnTimerTicked(object obj)
        {
        }
    }
}