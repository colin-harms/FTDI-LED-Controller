using libMPSSEWrapper;
using libMPSSEWrapper.Types;
using System;
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

        private Queue<byte[]> outputQueue;

        private Boolean looping;

        private Thread consumeThread;

        public SPIOutput()
        {
            Setup();

            outputQueue = new Queue<byte[]>();

            running = true;

            looping = false;

            consumeThread = new Thread(new ThreadStart(ConsumeQueue));
            consumeThread.Start();
        }

        public void OutputBytes(byte[] bytes)
        {
            outputQueue.Enqueue(bytes);
        }

        public IntPtr GetChannelHandle()
        {
            return channelHandle;
        }

        public void reset()
        {
            outputQueue.Clear();
        }

        public void setLooping(Boolean loop)
        {
            this.looping = loop;
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
                if (outputQueue.Count > 0)
                {
                    byte[] output = outputQueue.Dequeue();
                    WriteOutput(output);
                    if (looping)
                    {
                        outputQueue.Enqueue(output);
                    }
                }
                Thread.Sleep(0);
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
