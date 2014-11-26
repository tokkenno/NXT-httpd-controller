using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace NXTRemoteSC
{
    public class CMManager
    {
        private static SerialPort Connection = new SerialPort();

        public static Boolean Connect(Int32 npuerto)
        {
            try
            {
                Manager.Log("Conectando a puerto Serial...");
                Connection.PortName = "COM" + npuerto;
                Connection.Open();
                Connection.ReadTimeout = 1500;
                Manager.Log("Conexion correcta en el puerto COM" + npuerto + ".");
                return true;
            }
            catch
            {
                Manager.Log("Fallo al conectarse al puerto COM" + npuerto + ".");
                return false; 
            }
        }

        public static void Send(Byte[] comando)
        {
            NXTSendCommandAndGetReply(comando);
        }

        private static void NXTSendCommandAndGetReply(byte[] Command)
        {
            try
            {
                Byte[] MessageLength = { 0x00, 0x00 };

                MessageLength[0] = (byte)Command.Length;

                Connection.Write(MessageLength, 0, MessageLength.Length);
                Connection.Write(Command, 0, Command.Length);

                try
                {
                    int length = Connection.ReadByte();
                    Manager.Log(length.ToString());
                }
                catch
                {
                    Manager.Log("Sin contestación.");
                }
            }
            catch
            {
                Manager.Log("Error al enviar el comando al Brick. Esta conectado?");
            }
        }
    }
}
