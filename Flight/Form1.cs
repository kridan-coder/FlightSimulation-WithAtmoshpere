using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double dt = 0.1;
        const double g = 9.81;
        const double C = 0.15;
        const double rho = 1.29;

        double a;
        double v0;
        double y0;
        double S;
        double m;
        double k;

        double t;
        double x;
        double y;
        double vx;
        double vy;
        private void btStart_Click(object sender, EventArgs e)
        {
            a = (double)edAngle.Value;
            v0 = (double)edSpeed.Value;
            y0 = (double)edHeight.Value;
            m = (double)edWeight.Value;
            S = (double)edSquare.Value;
            k = 0.5 * C * S * rho / m;

            vx = v0 * Math.Cos(a * Math.PI / 180);
            vy = v0 * Math.Sin(a * Math.PI / 180);

            t = 0;
            x = 0;
            y = y0;
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(x, y);

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t += dt;
            vx = vx - k * vx * Math.Sqrt(vx * vx + vy * vy) * dt;
            vy = vy - (g + k * vy * Math.Sqrt(vx * vx + vy * vy)) * dt;

            x = x + vx * dt;
            y = y + vy * dt;

            chart1.Series[0].Points.AddXY(x, y);
            if (y <= 0) timer1.Stop();
        }
    }
}
