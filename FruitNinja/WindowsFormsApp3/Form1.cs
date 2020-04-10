using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Bitmap outJoin = Resource1.pear,
            join = Resource1.hand;

        private Point _targetPosition = new Point(300, 300);

        private Point direction = Point.Empty;
        private int _score = 0;
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            timer2.Interval = r.Next(300, 1000);
            direction.X = r.Next(-30, 30);
            direction.Y = r.Next(-30, 30);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var lokalPosition = this.PointToClient(Cursor.Position);

            _targetPosition.X += direction.X;
            _targetPosition.Y += direction.Y;

            if (_targetPosition.X < 10 || _targetPosition.X > 500)
            {
                direction.X *= -1;
            }
            if (_targetPosition.Y < 10 || _targetPosition.Y > 500)
            {
                direction.Y *= -1;
            }
            Point startPoint = new Point(lokalPosition.X - _targetPosition.X, lokalPosition.Y - _targetPosition.Y);
            float distanse = (float) Math.Sqrt(startPoint.X * startPoint.X + startPoint.Y * startPoint.Y);
            if(distanse<20)
            {
                AddScore(1);
            }

            var takeOutJoin = new Rectangle(_targetPosition.X - 50, _targetPosition.Y - 50, 100, 100);
            var takeJoin = new Rectangle(lokalPosition.X - 50, lokalPosition.Y - 50, 100, 100);
            g.DrawImage(join, takeJoin);

            g.DrawImage(outJoin, takeOutJoin);
        
        }
        private void AddScore(int score)
        {
            _score += score;
            lable.Text = _score.ToString();
        }
    }
}