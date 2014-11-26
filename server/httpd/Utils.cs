using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace Lib_HTTPd
{
    public static class Utils
    {
        public static String[] fileList(String ruta)
        {
            String[] files;

            try
            {
                DirectoryInfo dir = new DirectoryInfo(ruta);
                files = new String[dir.GetFiles().Length];

                for (Int32 i = 0; i < files.Length; i++)
                {
                    files[i] = dir.GetFiles()[i].FullName;
                }
            }
            catch
            {
                files = null;
            }

            return files;
        }

        public static Byte[] loadFile(String ruta)
        {
            if (!File.Exists(ruta))
            {
                return null;
            }

            FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.Read);

            BinaryReader reader = new BinaryReader(fs);

            byte[] bytes = new byte[fs.Length];

            reader.Read(bytes, 0, bytes.Length);

            reader.Close();
            fs.Close();

            return bytes;
        }

        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();
    }
}
