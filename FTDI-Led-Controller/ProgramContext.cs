using FTDI_Led_Controller.LedDrivers;
using FTDI_Led_Controller.LedEffects;
using FTDI_Led_Controller.Types;
using libMPSSEWrapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTDI_Led_Controller
{
    public class ProgramContext : ApplicationContext
    {
        SPIOutput spiOutput;

        LedStrip ledStrip {get; set;}

        Form1 mainForm;

        LedDriver driver{get;
        set;}

        Timer timer;

        public void SetDriver(LedDriver driver)
        {
            this.driver = driver;
        }
        
        public ProgramContext(Form1 form)
        {
            mainForm = form;
            mainForm.SetContext(this);
            form.FormClosed += new FormClosedEventHandler(this.Exit);

            LibMpsse.Init();
            spiOutput = new SPIOutput();
            ledStrip = new LedStrip(spiOutput, 120);
            Debug.WriteLine("Initialized");

            timer = new Timer();
            timer.Interval = 25;
            timer.Tick += new EventHandler(this.Tick);
            timer.Start();

            form.SetLedStrip(ledStrip);
            form.Show();
        }
        
        private void Tick(object sender, EventArgs e)
        {
            if (driver != null)
            {
                driver.Execute(this.ledStrip);
            }
        }

        public void Exit(object sender, EventArgs e)
        {
            spiOutput.Shutdown();
            LibMpsse.Cleanup();
            Debug.WriteLine("Cleaned Up");
            Application.Exit();
        }
    }
}
