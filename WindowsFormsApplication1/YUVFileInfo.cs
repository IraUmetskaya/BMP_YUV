using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class YUVFileInfo : FileInfo
    {
        public override byte[] FormHeader()
        {
            byte[] result = new byte[0];
            return result;
        }
    }
}
