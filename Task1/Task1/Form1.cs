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
            public Circle(Point point, int radius, SolidBrush color)
            {
                Center = point;
                Radius = radius;
                Brush = color;
            }
        }

        private Timer _timer;
        List<Circle> circles = new List<Circle>();
        List<Circle> circlesDelete = new List<Circle>();
        int _radius = 0;


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
                circles.Add(circle);
                if (circles.Count == 1)
                {
                    TimerCallback tm = new TimerCallback(PanelDisplay);
                    _timer = new Timer(tm, 0, 0, 5);
                }

            }
        }
        public void PanelDisplay(object obj)
        {

        }
    }
}