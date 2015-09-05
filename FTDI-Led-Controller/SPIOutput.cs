using libMPSSEWrapper;
using libMPSSEWrapper.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTDI_Led_Controller
{
    public class SPIOutput
    {
        private IntPtr channelHandle;

        private Boolean running;

        private BlockingCollection<byte[]> outputQueue;

        private Thread consumeThread;

        public SPIOutput()
        {
            Setup();

            outputQueue = new BlockingCollection<byte[]>();

            running = true;
            
            consumeThread = new Thread(new ThreadStart(ConsumeQueue));
            consumeThread.Start();
        }

        public void OutputBytes(byte[] bytes)
        {
            outputQueue.Add(bytes);
        }

        public IntPtr GetChannelHandle()
        {
            return channelHandle;
        }

        private void Setup()
        {
            Debug.WriteLine("Initializing SPI Output...");

            int channels;
            LibMpsseSpi.SPI_GetNumChannels(out channels);

            FtDeviceInfo info;
            LibMpsseSpi.SPI_GetChannelInfo(0, out info);

            FtChannelConfig config;
            config.ClockRate = 500000;
            config.LatencyTimer = 255;
            config.configOptions = FtConfigOptions.Mode0 | FtConfigOptions.CsDbus3;
            config.Pin = 0;
            config.reserved = 0;

            LibMpsseSpi.SPI_OpenChannel(0, out channelHandle);

            LibMpsseSpi.SPI_InitChannel(channelHandle, ref config);
        }

        public void Shutdown()
        {
            running = false;
            consumeThread.Join(2);
            LibMpsseSpi.SPI_CloseChannel(channelHandle);
        }

        private void ConsumeQueue()
        {
            Debug.WriteLine("Consume thread started");
            while (running)
            {
                byte[] output;
                if (outputQueue.TryTake(out output, 1000))
                {
                    WriteOutput(output);
                }
            }
            Debug.WriteLine("Consume thread finished");

        }

        private void WriteOutput(byte[] output)
        {
            int written;
            if (output != null)
            {
                FtResult result = LibMpsseSpi.SPI_Write(channelHandle, output, output.Length, out written, FtSpiTransferOptions.ChipselectDisable | FtSpiTransferOptions.SizeInBytes);
            }
                
        }
    }


}
