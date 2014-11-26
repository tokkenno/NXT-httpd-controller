using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXTLib
{
    public static class Utils
    {
        public static Byte[] SubBytes(Byte[] bytes, Int32 offset, Int32 length)
        {
            try
            {
                Byte[] aux = new Byte[length];

                for (int i = 0; i < length; i++)
                {
                    aux[i] = bytes[i + offset];
                }

                return aux;
            }
            catch
            {
                try
                {
                    Byte[] aux = new Byte[bytes.Length - offset];

                    for (int i = 0; i < length; i++)
                    {
                        aux[i] = bytes[i + offset];
                    }

                    return aux;
                }
                catch
                {
                    return null;
                }
            }

        }

        public static String BytesToString(Byte[] bytes)
        {
            return BitConverter.ToString(bytes);
        }

        public static String ByteToString(Byte b)
        {
            Byte[] by = { b };
            return BitConverter.ToString(by);
        }

        public static Byte[] StringToBytes(String s)
        {
            System.Text.ASCIIEncoding codificador = new System.Text.ASCIIEncoding();
            Byte[] aux = codificador.GetBytes(s);
            return aux;
        }

        public static String getString(byte[] text)
        {
            System.Text.ASCIIEncoding codificador = new System.Text.ASCIIEncoding();
            return codificador.GetString(text);
        }

        public static Byte[] ConcatBytes(Byte[] s1, Byte[] s2)
        {
            Byte[] aux = new Byte[s1.Length + s2.Length];

            for (Int32 i = 0; i < s1.Length; i++)
            {
                aux[i] = s1[i];
            }

            for (Int32 i = 0; i < s2.Length; i++)
            {
                aux[i + s1.Length] = s2[i];
            }

            return aux;
        }
    }
}
