using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Histogram
    {
        int[] grayHistogram;
        int[] redHistorgram;
        int[] greenHistorgram;
        int[] blueHistorgram;

        int[] grayTransformationHistogram;
        int[] redTransformationHistogram;
        int[] greenTransformationHistogram;
        int[] blueTransformationHistogram;

        public int[] BuildHistogram(BMPFileInfo imageFile)
        {
            int[] result = new int[256];
            int padding = 4 - imageFile.width * 3 % 4;
            if (padding == 4)
            {
                padding = 0;
            }
            int i = 0;
            for (int y = 0; y < imageFile.height; y++)
            {
                for (int x = 0; x < imageFile.width; x++)
                {
                    byte gray = GetY(imageFile.InfoBytes[i], imageFile.InfoBytes[i + 1], imageFile.InfoBytes[i + 2]);
                    result[gray]++;
                    i += 3;
                    if (x == imageFile.width - 1)
                    {
                        i += padding;
                    }
                }
            }
            return result;
        }

        public BMPFileInfo EqualizeHistogram(BMPFileInfo imageFile)
        {
            grayHistogram = new int[256];
            redHistorgram = new int[256];
            greenHistorgram = new int[256];
            blueHistorgram = new int[256];

            grayTransformationHistogram = new int[256];
            redTransformationHistogram = new int[256];
            greenTransformationHistogram = new int[256];
            blueTransformationHistogram = new int[256];

            BMPFileInfo result = imageFile.GetBMPCopy();
            int padding = 4 - imageFile.width * 3 % 4;
            if (padding == 4)
            {
                padding = 0;
            }
            int i = 0;
            for (int y = 0; y < imageFile.height; y++)
            {
                for (int x = 0; x < imageFile.width; x++)
                {
                    byte gray = GetY(imageFile.InfoBytes[i], imageFile.InfoBytes[i + 1], imageFile.InfoBytes[i + 2]);
                    grayHistogram[gray]++;
                    redHistorgram[imageFile.InfoBytes[i]]++;
                    greenHistorgram[imageFile.InfoBytes[i + 1]]++;
                    blueHistorgram[imageFile.InfoBytes[i+2]]++;
                    i += 3;
                    if (x == imageFile.width - 1)
                    {
                        i += padding;
                    }
                }
            }
            for (int k = 0; k <= 255; k++)
            {
                int sumR = 0;
                int sumG = 0;
                int sumB = 0; 
                for (int l = 0; l <= k; l++)
                {
                    sumR = sumR + redHistorgram[l];
                    sumG = sumG + greenHistorgram[l];
                    sumB = sumB + blueHistorgram[l];
                }
                redTransformationHistogram[k] = (255 * sumR) / (imageFile.width * imageFile.height);
                greenTransformationHistogram[k] = (255 * sumG) / (imageFile.width * imageFile.height);
                blueTransformationHistogram[k] = (255 * sumB) / (imageFile.width * imageFile.height);
            }
            i = 0;
            for (int y = 0; y < imageFile.height; y++)
            {
                for (int x = 0; x < imageFile.width; x++)
                {
                    result.InfoBytes[i] = (byte)redTransformationHistogram[result.InfoBytes[i]];
                    result.InfoBytes[i+1] = (byte)greenTransformationHistogram[result.InfoBytes[i+1]];
                    result.InfoBytes[i+2] = (byte)blueTransformationHistogram[result.InfoBytes[i+2]];
                    i += 3;
                    if (x == imageFile.width - 1)
                    {
                        i += padding;
                    }
                }
            }
            return result;
        }

        public BMPFileInfo EqualizeHistogramByYUV(BMPFileInfo bmp)
        {
            grayHistogram = new int[256];
            grayTransformationHistogram = new int[256];
            Converter converter = new Converter();

            var yuv = converter.GetYUVFromBMP(bmp);

            for (int y = 0; y < bmp.height; y++)
            {
                for (int x = 0; x < bmp.width; x++)
                {
                    byte gray = yuv.InfoBytes[bmp.width * y + x];
                    grayHistogram[gray]++;
                }
            }
            for (int k = 0; k <= 255; k++)
            {
                int sumGray = 0;
                for (int l = 0; l <= k; l++)
                {
                    sumGray = sumGray + grayHistogram[l];
                }
                grayTransformationHistogram[k] = (255 * sumGray) / (bmp.width * bmp.height);
            }
            for (int y = 0; y < bmp.height; y++)
            {
                for (int x = 0; x < bmp.width; x++)
                {
                    yuv.InfoBytes[bmp.width * y + x] = (byte)grayTransformationHistogram[yuv.InfoBytes[bmp.width * y + x]];
                }
            }
            return converter.GetBMPFromYUV(yuv, bmp.width, bmp.height);
        }

        private byte GetY(int R, int G, int B)
        {
            double result = 0.299 * R + 0.587 * G + 0.114 * B;
            return (byte)result;
        }
    }
}
