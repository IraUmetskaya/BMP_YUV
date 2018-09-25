using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApplication1
{
    public abstract class FileInfo
    {
        protected byte[] fileBytes = new byte[0];
        private byte[] headerBytes = new byte[0];
        private byte[] infoBytes = new byte[0];

        public byte[] FileBytes
        {
            get
            {
                return fileBytes;
            }
            set
            {
                fileBytes = value;
            }
        }

        public byte[] HeaderBytes
        {
            get
            {
                return headerBytes;
            }

            set
            {
                headerBytes = value;
            }
        }

        public byte[] InfoBytes
        {
            get
            {
                return infoBytes;
            }

            set
            {
                infoBytes = value;
            }
        }

        public byte[] FormFile()
        {
            FormHeader();
            byte[] result = new byte[headerBytes.Length + infoBytes.Length];
            Array.Copy(headerBytes, result, headerBytes.Length);
            Array.Copy(infoBytes, 0, result, headerBytes.Length, infoBytes.Length);
            fileBytes = result;
            return result;
        }

        public abstract byte[] FormHeader();

        public virtual void WriteToFile(string path)
        {
            FormFile();
            File.WriteAllBytes(path, FileBytes);
        }
    }
}
