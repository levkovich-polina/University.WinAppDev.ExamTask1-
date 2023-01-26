using System.Drawing;
using System.Windows.Forms;
using static Task1.Form1;
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
            List<Circle> circlesDelete = new List<Circle>();
            for (int k=0; k<_circles.Count; k++)
            {
                _circles[k].Radius++;
            }
            if (_circles.Count >= 2)
            {
                for (int i = 0; i < _circles.Count; i++)
                {
                    for (int n = 1; n < _circles.Count; n++)
                    {
                        if (Math.Sqrt(Math.Pow(Math.Abs(_circles[n].Center.X - _circles[i].Center.X), 2) + Math.Pow(Math.Abs(_circles[n].Center.Y - _circles[i].Center.Y), 2)) <= _circles[n].Radius + _circles[i].Radius)
                        {
                            circlesDelete.Add(_circles[i]);
                            circlesDelete.Add(_circles[n]);
                        }
                    }
                }
                for (int x = 0; x < circlesDelete.Count; x++)
                {
                    circlesDelete.RemoveAt(x);
                    Panel.Invalidate();
                    if (_circles.Count == 0)
                    {
                        _timer.Dispose();
                    }
                }
            }
            for (int a = 0; a < _circles.Count; a++)
            {
                if (Math.Abs(_circles[a].Center.Y - 0) <= _circles[a].Radius)
                {
                    _circles.RemoveAt(a);
                    Panel.Invalidate();
                    if (_circles.Count == 0)
                    {
                        _timer.Dispose();
                    }
                }
                if (Math.Abs(_circles[a].Center.Y - Panel.ClientSize.Height) <= _circles[a].Radius)
                {
                    _circles.RemoveAt(a);
                    Panel.Invalidate();
                    if (_circles.Count == 0)
                    {
                        _timer.Dispose();
                    }
                }
                if (Math.Abs(_circles[a].Center.X - 0) <= _circles[a].Radius)
                {
                    _circles.RemoveAt(a);
                    Panel.Invalidate();
                    if (_circles.Count == 0)
                    {
                        _timer.Dispose();
                    }
                }
                if (Math.Abs(_circles[a].Center.X - Panel.ClientSize.Width) <= _circles[a].Radius)
                {
                    _circles.RemoveAt(a);
                    Panel.Invalidate();
                    if (_circles.Count == 0)
                    {
                        _timer.Dispose();
                    }
                }
            }
            for(int m=0; m < _circles.Count; m++)
            {
                Graphics g = Panel.CreateGraphics();
                g.FillEllipse(_circles[m].Brush, _circles[m].Center.X - _circles[m].Radius, _circles[m].Center.Y - _circles[m].Radius, _circles[m].Radius * 2, _circles[m].Radius * 2);
            }
       
        }
    }
    
}