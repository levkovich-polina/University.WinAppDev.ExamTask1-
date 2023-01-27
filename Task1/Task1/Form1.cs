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
        Random _random = new Random();
        int _count = 0;

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
                _count++;
                QuantityLabel.Text = _count.ToString();
                SolidBrush brush = new SolidBrush(Color.FromArgb(_random.Next(255), _random.Next(255), _random.Next(255)));
                Circle circle = new Circle(e.Location, 0, brush);
                _circles.Add(circle);
                double speed = Convert.ToDouble(SpeedTextBox.Text);
                double difference = speed / 100.0;
                int reproduction = (int)(20 / difference);
                if (_circles.Count == 1)
                {
                    TimerCallback tm = new TimerCallback(OnTimerTicked);
                    _timer = new Timer(tm, 0, 0, reproduction);
                }

            }
        }
        public void OnTimerTicked(object obj)
        {
            List<Circle> circlesDelete = new List<Circle>();
            Graphics g = Panel.CreateGraphics();
            for (int k = 0; k < _circles.Count; k++)
            {
                _circles[k].Radius++;
            }
            if (_circles.Count >= 2)
            {
                for (int i = 0; i < _circles.Count; i++)
                {
                    for (int n = 1; n < _circles.Count; n++)
                    {
                        if (i != n)
                        {
                            var dx = _circles[n].Center.X - _circles[i].Center.X;
                            var dy = _circles[n].Center.Y - _circles[i].Center.Y;
                            var dRadius = _circles[n].Radius + _circles[i].Radius;
                            if (dx * dx + dy * dy <= dRadius * dRadius)
                            {
                                circlesDelete.Add(_circles[i]);
                                circlesDelete.Add(_circles[n]);
                            }
                        }

                    }
                }
                for (int x = 0; x < circlesDelete.Count; x++)
                {
                    _circles.Remove(circlesDelete[x]);
                    g.Clear(Color.White);
                    if (_circles.Count == 0)
                    {
                        _timer.Dispose();
                    }
                }
            }
            for (int a = 0; a < _circles.Count; a++)
            {
                var dx = _circles[a].Center.X;
                var dy = _circles[a].Center.Y;
                var dRadius = _circles[a].Radius;
                if (dy - 0 <= dRadius || Math.Abs(dy - Panel.ClientSize.Height) <= dRadius || dx - 0 <= dRadius || Math.Abs(dx - Panel.ClientSize.Width) <= dRadius)
                {
                    _circles.RemoveAt(a);
                    g.Clear(Color.White);
                    if (_circles.Count == 0)
                    {
                        _timer.Dispose();
                    }
                }
            }

            for (int m = 0; m < _circles.Count; m++)
            {
                var dx = _circles[m].Center.X;
                var dy = _circles[m].Center.Y;
                var dRadius = _circles[m].Radius;
                var brush = _circles[m].Brush;
                Invoke(() => { g.FillEllipse(brush, dx - dRadius, dy - dRadius, dRadius * 2, dRadius * 2); });
            }

        }
    }

}