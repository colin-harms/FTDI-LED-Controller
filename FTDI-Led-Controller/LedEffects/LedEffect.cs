using FTDI_Led_Controller.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTDI_Led_Controller.LedEffects
{
    abstract class LedEffect
    {
        public abstract void Apply(Pixel[] strip);

        public Pixel CreatePixel(CustomColor customColor)
        {
            Pixel pixel = new Pixel();
            pixel.brightness = 0xE0 | 0xF0;
            pixel.r = customColor.color.R;
            pixel.g = customColor.color.G;
            pixel.b = customColor.color.B;

            return pixel;
        }
    }
}
