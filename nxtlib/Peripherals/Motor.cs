using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXTLib.Peripherals
{
    public static class MotorInfo
    {
        public enum MotorConnectionStateList { CONNECTED, DISCONECTED };

        public enum MotorModeList { MOTORON = 0x01, BRAKE = 0x02, REGULATED = 0x04 };
        public enum MotorRegulationModeList { IDLE = 0x00, MOTOR_SPEED = 0x01, MOTOR_SYNC = 0x02 };
        public enum MotorRunStateList { IDLE = 0x00, RAMPUP = 0x10, RUNNING = 0x20, RAMPDOWN = 0x30 };

        public enum MotorPortList { PORT_A = 0x00, PORT_B = 0x01, PORT_C = 0x02 };
    }

    public class Motor
    {
        private MotorInfo.MotorConnectionStateList state;
        private SerialCommunication sc;

        private MotorInfo.MotorPortList motorPort;
        private Byte[] port;

        #region Constructores
        public Motor()
        {
            this.state = MotorInfo.MotorConnectionStateList.DISCONECTED;
        }

        public Motor(SerialCommunication communication, MotorInfo.MotorPortList portId)
        {
            this.sc = communication;

            if (sc.STATE == SerialCommunicationInfo.CONNECTION_STATE.CONNECTED)
            {
                this.state = MotorInfo.MotorConnectionStateList.CONNECTED;
            }

            this.motorPort = portId;
            this.port = new Byte[] { (byte)portId };
        }
        #endregion

        /// <summary>
        /// Funcion que establece el estado del motor.
        /// </summary>
        /// <param name="power"></param>
        /// <param name="mode"></param>
        /// <param name="regulationMode"></param>
        /// <param name="turnRatio"></param>
        /// <param name="runState"></param>
        /// <param name="tachoLimit">Grados que debe girar el motor (0 para girar sin parar)</param>
        /// <returns></returns>
        public Boolean SetState(Int16 power, MotorInfo.MotorModeList mode, MotorInfo.MotorRegulationModeList regulationMode, Int16 turnRatio, MotorInfo.MotorRunStateList runState, UInt32 tachoLimit)
        {
            if (this.sc.STATE == SerialCommunicationInfo.CONNECTION_STATE.CONNECTED)
            {
                Byte[] header = { 0x80, 0x04 };
                Byte[] power_p = { NormalizeValor(power) };
                Byte[] mode_p = { (byte)mode };
                Byte[] regulationMode_p = { (byte)regulationMode };
                Byte[] turnRatio_p = { NormalizeValor(turnRatio) };
                Byte[] runState_p = { (byte)runState };
                Byte[] tachoLimit_p = BitConverter.GetBytes(tachoLimit);

                Byte[] message = Utils.ConcatBytes(header,
                                    Utils.ConcatBytes(this.port,
                                        Utils.ConcatBytes(power_p,
                                            Utils.ConcatBytes(mode_p,
                                                Utils.ConcatBytes(regulationMode_p,
                                                    Utils.ConcatBytes(turnRatio_p,
                                                        Utils.ConcatBytes(runState_p, tachoLimit_p)
                                                    )
                                                )
                                            )
                                        )
                                    )
                                );
                Byte[] response = this.sc.Communication(message);

                if (response != null)
                {
                    try
                    {
                        if (response[0] == 0x02 && response[1] == message[1] && response[2] == 0x00)
                        {
                            return true;
                        }
                    }
                    catch
                    { }
                }
            }

            return false;
        }

        private Byte NormalizeValor(Int16 valor)
        {
            Int32 power_p;
            if (valor > 100)
            {
                power_p = 100;
            }
            else
            {
                if (valor < -100)
                {
                    power_p = -100;
                }
                else
                {
                    power_p = valor;
                }
            }

            return BitConverter.GetBytes(power_p)[0];
        }

        public MotorInfo.MotorConnectionStateList STATE
        {
            get { return this.state; }
        }

        public MotorInfo.MotorPortList PORT
        {
            get { return this.motorPort; }
        }
    }
}
