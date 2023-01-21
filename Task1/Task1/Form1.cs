using static Task1.Form1;
using Timer = System.Threading.Timer;

namespace Task1
{
    public partial class Form1 : Form
    {
        private Timer _timer;
        private int _diametr = 0;
        SolidBrush color;
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

        public Form1()
        {
            InitializeComponent();
            QuantityLabel.Text = "0";
            SpeedTextBox.Text = "100";
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            int radius = 0;
            if (Panel.Capture)
            {
                Circle circle = new Circle(new Point(e.X, e.Y), radius);             
                int num = 0;

                double speed = Convert.ToDouble(SpeedTextBox.Text);

                double difference = speed / 100.0;
                int reproduction = (int)(20 / difference);

                TimerCallback tm = new TimerCallback(Draw);
                _timer = new Timer(tm, num, 0, reproduction);
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Panel.Capture = false;
            }
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            int count = 0;
            if (e.Button == MouseButtons.Left)
            {
                Panel.Capture = true;
                count += 1;
                QuantityLabel.Text = count.ToString();
                Random random = new Random();       
                SolidBrush pen = new SolidBrush(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
                color = pen;
                PointToScreen(e.Location);
            }
        }
        public void Draw(object obj)
        {
            Graphics g = Panel.CreateGraphics();
            g.FillEllipse(color, Size.Width, Size.Height);
            _diametr++;
            if (Panel.Capture == false)
            {
                _timer.Dispose();
                _diametr = 0;
            }
        }
    }
}