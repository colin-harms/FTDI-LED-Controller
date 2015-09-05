using FTDI_Led_Controller.LedDrivers;
using FTDI_Led_Controller.LedEffects;
using FTDI_Led_Controller.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTDI_Led_Controller
{
    public partial class Form1 : Form
    {
        SolidColor solidColor;
        MouseFollower mouseFollower;

        ColorDialog dialog = new ColorDialog();

        ProgramContext context;

        public void SetLedStrip(LedStrip strip)
        {
            solidColor = new SolidColor();
            mouseFollower = new MouseFollower();
        }

        public void SetContext(ProgramContext context)
        {
            this.context = context;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RotatingColor color = new RotatingColor();
            color.Start();
            solidColor.SetColor(color);
            context.SetDriver(solidColor);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mouseFollower.SetColor(new StaticColor(dialog.Color));
                context.SetDriver(mouseFollower);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                solidColor.SetColor(new StaticColor(dialog.Color));
                context.SetDriver(solidColor);
            }
        }
    }
}
