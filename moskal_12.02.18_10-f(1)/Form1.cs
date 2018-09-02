using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moskal_12._02._18_10_f_1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            Graphics g = this.pictureBox1.CreateGraphics();
            int y0 = pictureBox1.Height / 2;
            int x0=pictureBox1.Width/2;
            Pen p1 = new Pen(Color.Black, 1);
            g.DrawLine(p1,0, y0,pictureBox1.Width,y0);
            g.DrawLine(p1, x0, pictureBox1.Height,x0 ,0);
            double a = double.Parse(textBox1.Text);
            double k = double.Parse(textBox2.Text);
            double c = double.Parse(textBox3.Text);
            Pen p2 = new Pen(Color.Red, 1);
            x0 = pictureBox1.Width / 2;
            y0 = pictureBox1.Height / 2;
            double x, y;
            x = 0;
            y = 0;
            for (int t=1;t<pictureBox1.Width;t++)
            {
                if (t + a != 0)
                {
                    x = (c / (t * t + t)) * Math.Pow((Math.Sin(k * Math.Sqrt(t))) / (Math.Cos(k * Math.Sqrt(t))), 2) + pictureBox1.Width / 2;
                    y = -1 * ((a * t * Math.Pow(Math.Cos(k * Math.Sqrt(t)), 2)) / (t + a)) + pictureBox1.Height / 2;
                    if (x < 1000 || x > -1000 || y < 1000 || y > -1000)
                    {
                        g.DrawLine(p2, x0, y0, Convert.ToInt64(x), Convert.ToInt64(y));
                        x0 = Convert.ToInt32(x);
                        y0 = Convert.ToInt32(y);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
            double a = double.Parse(textBox1.Text);
            double k = double.Parse(textBox2.Text);
            double c = double.Parse(textBox3.Text);
            chart1.Series[0].Points.Clear();
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 10;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 10;
            chart1.ChartAreas[0].AxisX.Minimum = -10;
            chart1.ChartAreas[0].AxisY.Minimum = -10;
            chart1.ChartAreas[0].AxisY.Maximum = 150;
            chart1.ChartAreas[0].AxisX.Maximum = 40;
            double x = 0;
            double y = 0;
            for (int t = 1; t <100; t++)
            {
                if (t + a != 0)
                {
                    chart1.Series[0].Points.AddXY(x, y);
                    x = (c / (t * t + t)) * Math.Pow((Math.Sin(k * Math.Sqrt(t))) / (Math.Cos(k * Math.Sqrt(t))), 2);
                    y = (a * t * Math.Pow(Math.Cos(k * Math.Sqrt(t)), 2)) / (t + a);
                    

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
