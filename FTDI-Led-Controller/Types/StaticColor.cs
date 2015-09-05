using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTDI_Led_Controller.Types
{
    public class StaticColor : CustomColor
    {
        public Color color
        {
            get;
            set;
        }

        public StaticColor(Color color)
        {
            this.color = color;
        }
    }
}
