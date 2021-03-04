using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flight.BusinessModel;

namespace Flight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Model model;
        private void btStart_Click(object sender, EventArgs e)
        {
            model = new Model(new Body() 
            {
                a = (double)edAngle.Value,
                v0 = (double)edSpeed.Value,
                y0 = (double)edHeight.Value,
                m = (double)edWeight.Value,
                S = (double)edSquare.Value,
            }, 
            new BusinessModel.Environment());

            model.ThrowBody();

            chart1.Series[0].Points.Clear();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddXY(model.body.x, model.body.y);
            if (!model.NextTick()) timer1.Stop();
        }
    }
}
