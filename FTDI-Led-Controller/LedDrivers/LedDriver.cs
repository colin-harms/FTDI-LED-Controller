using FTDI_Led_Controller.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTDI_Led_Controller.LedDrivers
{
    public interface LedDriver
    {
        void Execute(LedStrip strip);
    }
}
