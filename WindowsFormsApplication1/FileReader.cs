using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class FileReader
    {
        public static FileInfo ReadFile(string filePath)
        {
            FileInfo file = null;
            string ext = filePath.Substring(Math.Max(0, filePath.Length - 3)).ToLower();
            byte[] fileBytes = File.ReadAllBytes(filePath);
            switch (ext)
            {
                case "bmp":
                    file = ReadBMP(fileBytes);
                    break;
                case "yuv":
                    file = ReadYUV(fileBytes);
                    break; 
            }
            return file;
        }

        private static BMPFileInfo ReadBMP(byte[] fileBytes)
        {
            BMPFileInfo bmpFileInfo = new BMPFileInfo();
            bmpFileInfo.width = BitConverter.ToInt32(fileBytes, 18);
            bmpFileInfo.height = BitConverter.ToInt32(fileBytes, 22);
            bmpFileInfo.byteOff = BitConverter.ToInt32(fileBytes, 10);
            bmpFileInfo.byteSize = BitConverter.ToInt32(fileBytes, 2);
            bmpFileInfo.byteSize2 = BitConverter.ToInt32(fileBytes, 14);
            bmpFileInfo.bitCount = BitConverter.ToInt16(fileBytes, 28);
            bmpFileInfo.Comperssion = BitConverter.ToInt32(fileBytes, 30);
            bmpFileInfo.SizeImage = BitConverter.ToInt32(fileBytes, 34);
            bmpFileInfo.XPelsPerMeter = BitConverter.ToInt32(fileBytes, 38);
            bmpFileInfo.YPelsPerMeter = BitConverter.ToInt32(fileBytes, 42);
            bmpFileInfo.ClrUsed = BitConverter.ToInt32(fileBytes, 46);
            bmpFileInfo.ClrImportant = BitConverter.ToInt32(fileBytes, 50);
            bmpFileInfo.FileBytes = fileBytes;
            bmpFileInfo.InfoBytes = new byte[bmpFileInfo.SizeImage];
            bmpFileInfo.HeaderBytes = new byte[bmpFileInfo.byteSize - bmpFileInfo.SizeImage];
            Array.Copy(bmpFileInfo.FileBytes, 0, bmpFileInfo.HeaderBytes, 0, bmpFileInfo.HeaderBytes.Length);
            Array.Copy(bmpFileInfo.FileBytes, bmpFileInfo.byteOff, bmpFileInfo.InfoBytes, 0, bmpFileInfo.InfoBytes.Length);
            return bmpFileInfo;
        }
        
        private static YUVFileInfo ReadYUV(byte[] fileBytes)
        {
            YUVFileInfo yuvFileInfo = new YUVFileInfo();
            yuvFileInfo.FileBytes = fileBytes;
            yuvFileInfo.InfoBytes = fileBytes;
            return yuvFileInfo;
        }
    }
}
