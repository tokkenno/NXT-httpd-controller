using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace NXTLib
{
    public static class SerialCommunicationInfo
    {
        public enum CONNECTION_STATE { IDLE, CONNECTED, ERROR };
    }

    public class SerialCommunication
    {
        private SerialPort connection = new SerialPort();
        private Int32 timeout;

        private SerialCommunicationInfo.CONNECTION_STATE state = SerialCommunicationInfo.CONNECTION_STATE.IDLE;

        public SerialCommunication(String port)
        {
            if (IsComPort(port))
                connection.PortName = port.ToString();
            else
                throw new Exception();
        }

        public SerialCommunication(String port, Int32 timeout)
        {
            if (IsComPort(port))
                connection.PortName = port.ToString();
            else
                throw new Exception();

            this.timeout = timeout;
        }

        private Boolean IsComPort(String port)
        {
            try
            {
                if (port[0] == 'C' && port[1] == 'O' && port[2] == 'M')
                    return true;
                return false;
            }
            catch { return false; }
        }

        public SerialCommunicationInfo.CONNECTION_STATE Connect()
        {
            try
            {
                connection.Open();

                if (timeout > 5000)
                {
                    this.timeout = 5000;
                    this.connection.ReadTimeout = timeout;
                }
                else
                {
                    if (timeout < 50)
                    {
                        this.timeout = 50;
                        this.connection.ReadTimeout = timeout;
                    }
                    else
                        this.connection.ReadTimeout = timeout;
                }

                this.state = SerialCommunicationInfo.CONNECTION_STATE.CONNECTED;
                return SerialCommunicationInfo.CONNECTION_STATE.CONNECTED;
            }
            catch 
            {
                this.state = SerialCommunicationInfo.CONNECTION_STATE.IDLE;
                return SerialCommunicationInfo.CONNECTION_STATE.ERROR;
            }
        }

        public void Disconect()
        {
            connection.Close();
            this.state = SerialCommunicationInfo.CONNECTION_STATE.IDLE;
        }

        public Byte[] Communication (byte[] Command)
        {
            try
            {
                Byte[] MessageLength = { 0x00, 0x00 };

                MessageLength[0] = (byte)Command.Length;

                this.connection.Write(MessageLength, 0, MessageLength.Length);
                this.connection.Write(Command, 0, Command.Length);

                int length = connection.ReadByte() + 256 * connection.ReadByte();

                Byte[] msg = new Byte[length];

                for (int i = 0; i < length; i++)
                    msg[i] = System.Convert.ToByte(connection.ReadByte());

                return msg;
            }
            catch
            {
                return null;
            }
        }

        #region Respuestas
        public SerialCommunicationInfo.CONNECTION_STATE STATE
        {
            get
            {
                return this.state;
            }
        }

        public String PORT
        {
            get
            {
                return this.connection.PortName;
            }
        }

        public Int32 TIMEOUT
        {
            get
            {
                return this.timeout;
            }
        }
        #endregion
    }
}
