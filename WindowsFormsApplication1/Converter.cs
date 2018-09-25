using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Converter
    {
        public BMPFileInfo GetBMPFromYUV(YUVFileInfo yuv, int width, int height)
        {
            BMPFileInfo bmp = new BMPFileInfo();
            int padding = 4 - width * 3 % 4;
            if (padding == 4)
            {
                padding = 0;
            }
            int size = width * height;
            bmp.width = width;
            bmp.height = height;
            bmp.byteSize2 = 40;
            bmp.byteOff = 14 + bmp.byteSize2;
            bmp.bitCount = 24;
            bmp.SizeImage = bmp.bitCount / 8 * bmp.width * bmp.height + bmp.height * padding;
            bmp.byteSize = bmp.byteOff + bmp.SizeImage;
            bmp.ClrImportant = 0;
            bmp.ClrUsed = 0;
            bmp.XPelsPerMeter = 2835;
            bmp.YPelsPerMeter = 2835;
            bmp.Comperssion = 0;
            bmp.InfoBytes = new byte[size * 3 + padding * height];
            byte[] yBytes = new byte[size];
            byte[] uBytes = new byte[size / 4];
            byte[] vBytes = new byte[size / 4];
            byte[] rBytes = new byte[size];
            byte[] bBytes = new byte[size];
            byte[] gBytes = new byte[size];
            try
            {
                Array.Copy(yuv.InfoBytes, 0, yBytes, 0, size);
                Array.Copy(yuv.InfoBytes, size, vBytes, 0, size / 4);
                Array.Copy(yuv.InfoBytes, size + size / 4, uBytes, 0, size / 4);
            }
            catch
            {
                throw new Exception("Wrong width or height");
            }
            int i = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int vuIndex = (int)(x / 2) + (int)(width / 2) * (int)(y / 2);
                    if (vuIndex > size / 4)
                        vuIndex = size / 4 - 1;
                    int V = vBytes[vuIndex];
                    int U = uBytes[vuIndex];
                    rBytes[i] = (byte)GetR(yBytes[i], V);
                    bBytes[i] = (byte)GetB(yBytes[i], U);
                    gBytes[i] = (byte)GetG(yBytes[i], U, V);
                    i++;
                }
            }
            rBytes = rBytes.Reverse().ToArray();
            bBytes = bBytes.Reverse().ToArray();
            gBytes = gBytes.Reverse().ToArray();
            i = 0;
            int j = 0;
            byte[] infoBytesW = new byte[width * 3];
            bmp.InfoBytes = new byte[0];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    infoBytesW[j++] = bBytes[i];
                    infoBytesW[j++] = gBytes[i];
                    infoBytesW[j++] = rBytes[i];
                    i++;
                    if (x == width - 1)
                    {
                        infoBytesW = infoBytesW.Reverse().ToArray();
                        bmp.InfoBytes = bmp.InfoBytes.Concat(infoBytesW).ToArray();
                        byte[] paddingAr = new byte[padding];
                        bmp.InfoBytes = bmp.InfoBytes.Concat(paddingAr).ToArray();
                        j = 0;
                    }
                }
            }

            bmp.FormFile();
            return bmp;
        }

        public YUVFileInfo GetYUVFromBMP(BMPFileInfo bmp)
        {
            YUVFileInfo yuv = new YUVFileInfo();
            int size = bmp.width * bmp.height;
            byte[] yBytes = new byte[size];
            byte[] uBytes = new byte[size / 4];
            byte[] vBytes = new byte[size / 4];
            byte[] rBytes = new byte[size];
            byte[] gBytes = new byte[size];
            byte[] bBytes = new byte[size];
            int padding = 4 - bmp.width * 3 % 4;
            if (padding == 4)
            {
                padding = 0;
            }
            int i = 0;
            for (int y = 0; y < bmp.height; y++)
            {
                for (int x = 0; x < bmp.width; x++)
                {
                    rBytes[size - bmp.width * y - bmp.width + x] = bmp.InfoBytes[i++];
                    gBytes[size - bmp.width * y - bmp.width + x] = bmp.InfoBytes[i++];
                    bBytes[size - bmp.width * y - bmp.width + x] = bmp.InfoBytes[i++];
                    if (x == bmp.width - 1)
                    {
                        i += padding;
                    }
                }
            }
            int uCount = 0;
            int vCount = 0;
            for (int y = 0; y < bmp.height; y++)
            {
                for (int x = 0; x < bmp.width; x++)
                {
                    yBytes[bmp.width * y + x] = (byte)GetY(rBytes[bmp.width * y + x], gBytes[bmp.width * y + x], bBytes[bmp.width * y + x]);
                    if (x % 2 == 0 && y % 2 == 0)
                    {
                        int averageR = rBytes[bmp.width * y + x];
                        int averageG = gBytes[bmp.width * y + x];
                        int averageB = bBytes[bmp.width * y + x];
                        bool cond1 = y < bmp.height - 1;
                        bool cond2 = x < bmp.width - 1;
                        if (cond1 && cond2)
                        {
                            averageR = (averageR + rBytes[bmp.width * (y + 1) + x] + rBytes[bmp.width * y + x + 1] + rBytes[bmp.width * (y + 1) + x + 1])/4;
                            averageG = (averageG + gBytes[bmp.width * (y + 1) + x] + gBytes[bmp.width * y + x + 1] + gBytes[bmp.width * (y + 1) + x + 1])/4;
                            averageB = (averageB + bBytes[bmp.width * (y + 1) + x] + bBytes[bmp.width * y + x + 1] + bBytes[bmp.width * (y + 1) + x + 1])/4;
                        }
                        else if (cond1)
                        {
                            averageR = (averageR + rBytes[bmp.width * (y + 1) + x]) / 2;
                            averageG = (averageG + gBytes[bmp.width * (y + 1) + x]) / 2;
                            averageB = (averageB + bBytes[bmp.width * (y + 1) + x]) / 2;
                        }
                        else if (cond2)
                        {
                            averageR = (averageR + rBytes[bmp.width * y + x + 1]) / 2;
                            averageG = (averageG + gBytes[bmp.width * y + x + 1]) / 2;
                            averageB = (averageB + bBytes[bmp.width * y + x + 1]) / 2;
                        }
                        if (uCount < size / 4 && vCount < size / 4)
                        {
                            uBytes[uCount++] = (byte)GetU(averageR, averageG, averageB);
                            vBytes[vCount++] = (byte)GetV(averageR, averageG, averageB);
                        }
                    }
                }
            }
            yuv.InfoBytes = yBytes;
            yuv.InfoBytes = yuv.InfoBytes.Concat(vBytes).ToArray();
            yuv.InfoBytes = yuv.InfoBytes.Concat(uBytes).ToArray();
            return yuv;
        }

        private int GetY(int R, int G, int B)
        {
            double result = 0.299 * R + 0.587 * G + 0.114 * B;
            return (int)result;
        }

        private int GetU(int R, int G, int B)
        {
            double result = -0.14713 * R - 0.28886 * G + 0.436 * B + 128;
            return (int)result;
        }

        private int GetV(int R, int G, int B)
        {
            double result = 0.615 * R - 0.51499 * G - 0.10001 * B + 128;
            return (int)result;
        }

        private int GetR(int Y, int V)
        {
            double result = Y + 1.13983 * (V - 128);
            if (result > 255)
                return 255;
            else
                return (int)Math.Abs(result);
        }

        private int GetG(int Y, int U, int V)
        {
            double result = Y - 0.39465 * (U - 128) - 0.5806 * (V - 128);
            if (result > 255)
                return 255;
            else
                return (int)Math.Abs(result);
        }

        private int GetB(int Y, int U)
        {
            double result = Y + 2.03211 * (U - 128);
            if (result > 255)
                return 255;
            else
                return (int)Math.Abs(result);
        }
    }
}
