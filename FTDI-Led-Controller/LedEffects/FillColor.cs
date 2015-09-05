using FTDI_Led_Controller.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTDI_Led_Controller.LedEffects
{
    class FillColor : LedEffect
    {
        CustomColor color;

        public FillColor()
        {
            color = new StaticColor(Color.Black);
        }

        public FillColor(CustomColor color)
        {
            this.color = color;
        }

        public void SetColor(CustomColor color)
        {
            this.color = color;
        }

        public override void Apply(Types.Pixel[] strip)
        {
            for (Int32 index = 0; index < strip.Length; index++)
            {
                strip[index] = CreatePixel(color);
            }
        }
    }
}
