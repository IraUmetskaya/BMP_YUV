using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class BMPFileInfo: FileInfo
    {
        public int width;
        public int height;
        public int byteOff;
        public int byteSize; //Размер BITMAPFILEHEADER
        public int byteSize2; //Размер структуры с 32-битными информационными полями
        public short bitCount;
        public int Comperssion;
        public int SizeImage;
        public int XPelsPerMeter;
        public int YPelsPerMeter;
        public int ClrUsed;
        public int ClrImportant;
        public const short bytePlanes = 1;
        public const short byteType = 0x4D42;
        public const short byteReserved1 = 0;
        public const short byteReserved2 = 0;

        public override byte[] FormHeader()
        {
            byte[] _byteType = BitConverter.GetBytes(byteType);
            byte[] _width = BitConverter.GetBytes(width);
            byte[] _height = BitConverter.GetBytes(height);
            byte[] _byteOff = BitConverter.GetBytes(byteOff);
            byte[] _byteSize = BitConverter.GetBytes(byteSize);
            byte[] _byteSize2 = BitConverter.GetBytes(byteSize2);
            byte[] _bitCount = BitConverter.GetBytes(bitCount);
            byte[] _compression = BitConverter.GetBytes(Comperssion);
            byte[] _sizeImage = BitConverter.GetBytes(SizeImage);
            byte[] _xPelsPerMeter = BitConverter.GetBytes(XPelsPerMeter);
            byte[] _YPelsPerMeter = BitConverter.GetBytes(YPelsPerMeter);
            byte[] _clrUsed = BitConverter.GetBytes(ClrUsed);
            byte[] _clrImportant = BitConverter.GetBytes(ClrImportant);
            byte[] _bytePlanes = BitConverter.GetBytes(bytePlanes);
            byte[] _byteReserved1 = BitConverter.GetBytes(byteReserved1);
            byte[] _byteReserved2 = BitConverter.GetBytes(byteReserved2);

            byte[] result = _byteType.Concat(_byteSize).ToArray();
            result = result.Concat(_byteReserved1).ToArray();
            result = result.Concat(_byteReserved2).ToArray();
            result = result.Concat(_byteOff).ToArray();
            result = result.Concat(_byteSize2).ToArray();
            result = result.Concat(_width).ToArray();
            result = result.Concat(_height).ToArray();
            result = result.Concat(_bytePlanes).ToArray();
            result = result.Concat(_bitCount).ToArray();
            result = result.Concat(_compression).ToArray();
            result = result.Concat(_sizeImage).ToArray();
            result = result.Concat(_xPelsPerMeter).ToArray();
            result = result.Concat(_YPelsPerMeter).ToArray();
            result = result.Concat(_clrUsed).ToArray();
            result = result.Concat(_clrImportant).ToArray();

            HeaderBytes = result;

            return result;
        }

        public BMPFileInfo GetBMPCopy()
        {
            BMPFileInfo copy = (BMPFileInfo)this.MemberwiseClone();
            Array.Copy(InfoBytes, copy.InfoBytes, InfoBytes.Length);
            Array.Copy(HeaderBytes, copy.HeaderBytes, HeaderBytes.Length);
            Array.Copy(FileBytes, copy.FileBytes, FileBytes.Length);
            return copy;
        }
    }
}
