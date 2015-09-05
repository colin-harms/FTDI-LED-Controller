using FTDI_Led_Controller.LedEffects;
using FTDI_Led_Controller.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTDI_Led_Controller.LedDrivers
{
    class SolidColor : LedDriver
    {
        FillColor effect;

        Timer timer;

        public SolidColor()
        {
            this.effect = new FillColor();
        }

        public void SetColor(CustomColor color)
        {
            effect.SetColor(color);
        }

        public void Execute(LedStrip strip)
        {
            Pixel[] array = strip.GetPixelArray();
            effect.Apply(array);
            strip.OutputPixels(array);
        }
    }
}
