using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Transformation
    {
        public BMPFileInfo GetGrayscale(BMPFileInfo imageFile)
        {
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
                    byte grey = GetY(result.InfoBytes[i], result.InfoBytes[i + 1], result.InfoBytes[i + 2]);
                    for (int k = 0; k < 3; k++)
                    {
                        result.InfoBytes[i] = (byte)grey;
                        i++;
                    }
                    if (x == imageFile.width - 1)
                    {
                        i += padding;
                    }
                }
            }
            return result;
        }

        public BMPFileInfo GetNegative(BMPFileInfo imageFile)
        {
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
                    result.InfoBytes[i] = (byte)(255 - result.InfoBytes[i++]);
                    result.InfoBytes[i] = (byte)(255 - result.InfoBytes[i++]);
                    result.InfoBytes[i] = (byte)(255 - result.InfoBytes[i++]);
                    if (x == imageFile.width - 1)
                    {
                        i += padding;
                    }
                }
            }
            return result;
        }

        public BMPFileInfo GetLogarithmic(BMPFileInfo imageFile)
        {
            BMPFileInfo result = imageFile.GetBMPCopy();
            int padding = 4 - imageFile.width * 3 % 4;
            if (padding == 4)
            {
                padding = 0;
            }
            int i = 0;
            double constant = GetLogConst(255);
            for (int y = 0; y < imageFile.height; y++)
            {
                for (int x = 0; x < imageFile.width; x++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        result.InfoBytes[i] = GetLogValue(constant, result.InfoBytes[i]);
                        i++;
                    }
                    if (x == imageFile.width - 1)
                    {
                        i += padding;
                    }
                }
            }
            return result;
        }

        public BMPFileInfo GetReverseLogarithmic(BMPFileInfo imageFile)
        {
            BMPFileInfo result = imageFile.GetBMPCopy();
            int padding = 4 - imageFile.width * 3 % 4;
            if (padding == 4)
            {
                padding = 0;
            }
            int i = 0;
            double constant = GetLogConst(255);
            for (int y = 0; y < imageFile.height; y++)
            {
                for (int x = 0; x < imageFile.width; x++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        result.InfoBytes[i] = GetReverseLogValue(constant, result.InfoBytes[i]);
                        i++;
                    }
                    if (x == imageFile.width - 1)
                    {
                        i += padding;
                    }
                }
            }
            return result;
        }

        public BMPFileInfo GetPower(BMPFileInfo imageFile, double gamma)
        {
            BMPFileInfo result = imageFile.GetBMPCopy();
            int padding = 4 - imageFile.width * 3 % 4;
            if (padding == 4)
            {
                padding = 0;
            }
            int i = 0;
            double constant = GetPowConst(gamma);
            for (int y = 0; y < imageFile.height; y++)
            {
                for (int x = 0; x < imageFile.width; x++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (result.InfoBytes[i] == 0)
                            result.InfoBytes[i] = GetPowValue(gamma, constant, 1);
                        else if (result.InfoBytes[i] == 255)
                            result.InfoBytes[i] = GetPowValue(gamma, constant, 254);
                        else
                            result.InfoBytes[i] = GetPowValue(gamma, constant, result.InfoBytes[i]);
                        i++;
                    }
                    if (x == imageFile.width - 1)
                    {
                        i += padding;
                    }
                }
            }
            return result;
        }

        public BMPFileInfo GetPiecewiseLinear(BMPFileInfo imageFile, List<Point> points)
        {
            int index0 = points.FindIndex(p => p.X == 0);
            int index255 = points.FindIndex(p => p.X == 255);
            if (index0 == -1)
                points.Add(new Point(0, 0));
            if (index255 == -1)
                points.Add(new Point(255, 255));
            points = points.OrderBy(p => p.X).ToList();
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
                    for (int k = 0; k < 3; k++)
                    {
                        int index = 0;
                        for (int j = 0; j < points.Count; j++)
                        {
                            if (result.InfoBytes[i] <= points[j].X)
                            {
                                index = j;
                                break;
                            }
                        }
                        if (index == 0 || result.InfoBytes[i] == points[index].X)
                            result.InfoBytes[i] = points[index].Y;
                        else
                        {
                            double coef = (points[index].Y - points[index - 1].Y) / (points[index].X - points[index - 1].X);
                            double b = points[index].Y - coef * points[index].X;
                            result.InfoBytes[i] = (byte)(coef * result.InfoBytes[i] + b);
                        } 
                        i++;
                    }
                    if (x == imageFile.width - 1)
                    {
                        i += padding;
                    }
                }
            }
            return result;
        }

        private byte GetLogValue(double constant, byte color)
        {
            int result = (int)(constant * Math.Log(color + 1));
            if (result > 255)
                return 255;
            if (result < 0)
                return 0;
            else
                return (byte)result;
        }

        private byte GetReverseLogValue(double constant, byte color)
        {
            int result = (int)(Math.Exp(color/constant) - 1);
            if (result > 255)
                return 255;
            if (result < 0)
                return 0;
            else
                return (byte)result;
        }

        private byte GetPowValue(double gamma, double constant, byte color)
        {
            double result = constant * Math.Pow(color, gamma);
            if (result > 255)
                return 255;
            if (result < 0)
                return 0;
            else
                return (byte)result;
        }

        private byte GetY(int R, int G, int B)
        {
            double result = 0.299 * R + 0.587 * G + 0.114 * B;
            return (byte)result;
        }

        private double GetLogConst(int MaxColor)
        {
            return 255 / Math.Log(1 + MaxColor);
        }

        private double GetPowConst(double gamma)
        {
            return (255 / Math.Pow(255, gamma)); 
        }
    }
}
