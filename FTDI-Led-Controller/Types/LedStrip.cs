using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTDI_Led_Controller.Types
{
    public class LedStrip
    {
        private int numLeds;

        private int outputLength;

        private SPIOutput spiOutput;

        public LedStrip(SPIOutput spiOutput, int numLeds)
        {
            this.spiOutput = spiOutput;
            this.numLeds = numLeds;
            this.outputLength = 4 + (numLeds * 4) + (numLeds / 8);
        }

        public Pixel[] GetPixelArray()
        {
            return new Pixel[numLeds];
        }
        /*
        public byte[][] generateTransition(Color toColor, int steps)
        {
            byte[][] outputArray = new byte[steps][];
            if (color.HasValue)
            {
                Color fromColor = color.Value;

                double rFactor = (toColor.R - fromColor.R) / (double)steps;
                double gFactor = (toColor.G - fromColor.G) / (double)steps;
                double bFactor = (toColor.B - fromColor.B) / (double)steps;

                Debug.WriteLine("R factor: {0}, G: {1}, B: {2}", rFactor,gFactor,bFactor);

                for (int i = 0; i < steps - 1; i++) 
                {
                    int r = fromColor.R + Convert.ToInt16(rFactor * i);
                    int g = fromColor.G + Convert.ToInt16(gFactor * i);
                    int b = fromColor.B + Convert.ToInt16(bFactor * i);
                    outputArray[i] = generateColor(Color.FromArgb(r, g, b));
                }
            }
            outputArray[steps - 1] = generateColor(toColor);
            return outputArray;
        }
        */


        private void outputArray(byte[][] output)
        {
            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] != null)
                {
                    spiOutput.OutputBytes(output[i]);
                    //Debug.WriteLine("Outputting {0}", i);
                }
            }
        }

        private byte[] createOutputArray()
        {
            byte[] output = new byte[outputLength];

            for (int i = 0; i < 4; i++)
            {
                output[i] = 0x00;
            }

            for (int i = 4 + (numLeds * 4); i < outputLength; i++)
            {
                output[i] = 0xFF;
            }

            return output;
        }

        public void OutputPixels(Pixel[] pixels)
        {
            byte[] o = createOutputArray();
            
            for (int i = 0; i < pixels.Length; i++)
            {
                o[4 + (i * 4)] = pixels[i].brightness;
                o[4 + (i * 4) + 1] = pixels[i].b;
                o[4 + (i * 4) + 2] = pixels[i].g;
                o[4 + (i * 4) + 3] = pixels[i].r;

            }

            spiOutput.OutputBytes(o);
        }

        public int GetNumLeds()
        {
            return numLeds;
        }
    }
    
}
