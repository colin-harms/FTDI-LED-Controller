using FTDI_Led_Controller.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTDI_Led_Controller.LedEffects
{
    public class RotatingColor : CustomColor
    {
        public Color color
        {
            get { return hslcolor; }
        }

        Timer timer;

        Int16 hue;

        Int16 saturation;

        Int16 brightness;

        HSLColor hslcolor;

        public RotatingColor()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(this.Tick);
            timer.Interval = 50;
            hslcolor = new HSLColor(0.0, 240.0, 120.0);
        }

        public void Tick(object sender, EventArgs args)
        {
            hslcolor.Hue = hue;
            hue++;
            if (hue >= 240)
                hue = 0;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}
