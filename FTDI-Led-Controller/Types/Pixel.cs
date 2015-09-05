using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FTDI_Led_Controller.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Pixel
    {
        public byte brightness;
        public byte b;
        public byte g;
        public byte r;
    }


    
}
