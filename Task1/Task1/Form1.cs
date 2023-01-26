using Timer = System.Threading.Timer;

namespace Task1
{
    public partial class Form1 : Form
    {
        private Timer _timer;
        Point cursor;
        List<Circle> circles = new List<Circle>();
        List<Circle> circlesDelete = new List<Circle>();
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


        int num = 0;
        int radius = 0;
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Panel.Capture == true)
            {
                Circle circle = new Circle(cursor, radius);
                circles.Add(circle);
                if (circles.Count == 1)
                {
                    TimerCallback tm = new TimerCallback(Draw);
                    _timer = new Timer(tm, num, 0, 5);
                }
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
                cursor = new Point(e.X, e.Y);
                //count += 1;
                //QuantityLabel.Text = count.ToString();
                Random random = new Random();
                SolidBrush pen = new SolidBrush(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
                color = pen;
            }
        }

        public void Draw(object obj)
        {
            radius++;
            if (circles.Count >= 2)
            {
                for (int i = 0; i < circles.Count; i++)
                {
                    for (int n = 1; n < circles.Count; n++)
                    {
                        if (Math.Sqrt(Math.Pow(Math.Abs(circles[n].Center.X - circles[i].Center.X), 2) + Math.Pow(Math.Abs(circles[n].Center.Y - circles[i].Center.Y), 2)) <= circles[n].Radius + circles[i].Radius)
                        {
                            circlesDelete.Add(circles[i]);
                            circlesDelete.Add(circles[n]);
                        }
                    }
                }
                for (int x = 0; x < circles.Count; x++)
                {
                    circlesDelete.RemoveAt(x);
                    if (circles.Count == 0)
                    {
                        _timer.Dispose();
                    }
                }
            }
            for (int a = 0; a < circles.Count; a++)
            {
                if (Math.Abs(circles[a].Center.Y - 0) <= circles[a].Radius)
                {
                    circles.RemoveAt(a);
                    Panel.Invalidate();
                    if (circles.Count == 0)
                    {
                        _timer.Dispose();
                    }
                }
                if (Math.Abs(circles[a].Center.Y - Panel.ClientSize.Height) <= circles[a].Radius)
                {
                    circles.RemoveAt(a);
                    Panel.Invalidate();
                    if (circles.Count == 0)
                    {
                        _timer.Dispose();
                    }
                }
            }
            Graphics g = Panel.CreateGraphics();
            g.FillEllipse(color, cursor.X - radius, cursor.Y - radius, radius * 2, radius * 2);
        }
    }
}