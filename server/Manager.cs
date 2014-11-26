using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXTRemoteSC
{
    public static class Manager
    {
        private static Lib_HTTPd.httpd httpd = new Lib_HTTPd.httpd();

        public static void Initialize()
        {
            Lib_HTTPd.Utils.AllocConsole();
        }

        public static Boolean ConnectCOM(Int32 com)
        {
            return CMManager.Connect(com);
        }

        public static Boolean ConnectHTTP(Int32 port)
        {
            return httpd.Start();
        }

        public static void Log(String msg)
        {
            System.Console.WriteLine(msg);
        }

        public static void Centrar()
        {
            byte[] fcom = { 0x00, 0x00, 0x00, 0x05 };
            byte[] vcom = { 0x00, 0x00, 0x00, 0x00 };

            byte[] re = new byte[fcom.Length + vcom.Length];
            System.Buffer.BlockCopy(fcom, 0, re, 0, fcom.Length);
            System.Buffer.BlockCopy(vcom, 0, re, fcom.Length, vcom.Length);

            CMManager.Send(re);
        }

        public static void Izquierda()
        {
            byte[] fcom = { 0x00, 0x00, 0x00, 0x03 };
            byte[] vcom = { 0x00, 0x00, 0x00, 0x36 };

            byte[] re = new byte[fcom.Length + vcom.Length];
            System.Buffer.BlockCopy(fcom, 0, re, 0, fcom.Length);
            System.Buffer.BlockCopy(vcom, 0, re, fcom.Length, vcom.Length);

            CMManager.Send(re);
        }

        public static void Derecha()
        {
            byte[] fcom = { 0x00, 0x00, 0x00, 0x04 };
            byte[] vcom = { 0x00, 0x00, 0x00, 0x36 };

            byte[] re = new byte[fcom.Length + vcom.Length];
            System.Buffer.BlockCopy(fcom, 0, re, 0, fcom.Length);
            System.Buffer.BlockCopy(vcom, 0, re, fcom.Length, vcom.Length);

            CMManager.Send(re);
        }

        public static void Acelerar()
        {
            byte[] fcom;
            byte[] vcom;
            fcom = new Byte[] { 0x00, 0x00, 0x00, 0x01 };
            vcom = new Byte[] { 0x00, 0x00, 0x04, 0x01 };

            byte[] re = new byte[fcom.Length + vcom.Length];
            System.Buffer.BlockCopy(fcom, 0, re, 0, fcom.Length);
            System.Buffer.BlockCopy(vcom, 0, re, fcom.Length, vcom.Length);

            CMManager.Send(re);
        }

        public static void Frenar()
        {
            byte[] fcom;
            byte[] vcom;
            fcom = new Byte[] { 0x00, 0x00, 0x00, 0x00 };
            vcom = new Byte[] { 0x00, 0x00, 0x00, 0x01 };

            byte[] re = new byte[fcom.Length + vcom.Length];
            System.Buffer.BlockCopy(fcom, 0, re, 0, fcom.Length);
            System.Buffer.BlockCopy(vcom, 0, re, fcom.Length, vcom.Length);

            CMManager.Send(re);
        }

        public static void Atras()
        {
            byte[] fcom;
            byte[] vcom;
            fcom = new Byte[] { 0x00, 0x00, 0x00, 0x02 };
            vcom = new Byte[] { 0x00, 0x00, 0x02, 0x01 };

            byte[] re = new byte[fcom.Length + vcom.Length];
            System.Buffer.BlockCopy(fcom, 0, re, 0, fcom.Length);
            System.Buffer.BlockCopy(vcom, 0, re, fcom.Length, vcom.Length);

            CMManager.Send(re);
        }

        public static void HttpCommand(String commando)
        {
            if (commando.Contains("acelerar.html"))
                Acelerar();
            if (commando.Contains("atras.html"))
                Atras();
            if (commando.Contains("derecha.html"))
                Derecha();
            if (commando.Contains("izquierda.html"))
                Izquierda();
            if (commando.Contains("frenar.html"))
                Frenar();
            if (commando.Contains("medio.html"))
                Centrar();
        }
    }
}
