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
    class MouseFollower : LedDriver
    {
        int width = 3840;

        FillColor effect;

        RotatingColor generator;

        public MouseFollower()
        {
            this.effect = new FillColor();

            generator = new RotatingColor();
            generator.Start();
        }

        public void SetColor(CustomColor color)
        {
            effect.SetColor(color);
        }

        public void Execute(LedStrip strip)
        {
            int highlight = (strip.GetNumLeds() - 1) * Cursor.Position.X / width;
            Pixel[] pixels = strip.GetPixelArray();
            effect.Apply(pixels);
            pixels[119 - highlight] = effect.CreatePixel(new StaticColor(Color.White));
            strip.OutputPixels(pixels);
        }
    }
}
