using Timer = System.Threading.Timer;

namespace Task1
{
    public partial class Form1 : Form
    {
      
        Point cursor;
        List<Circle> list = new List<Circle>();
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

        int radius = 0;
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Panel.Capture == true)
            {
                Circle circle = new Circle(cursor, radius);
                list.Add(circle);
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
            if (e.Button == MouseButtons.Left)
            {
                Panel.Capture = true;
                cursor = new Point(e.X, e.Y);
            }
        }

        public void Draw(object obj)
        {
         
        }
    }
}