using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTDI_Led_Controller
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ProgramContext context = new ProgramContext(new MainForm());
            Application.EnableVisualStyles();
            Application.Run(context);
        }

    }
}
