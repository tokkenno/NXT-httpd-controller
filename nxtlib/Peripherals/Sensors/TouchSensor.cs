using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXTLib.Peripherals.Sensors
{
    public class TouchSensor : Sensors.Sensor
    {
        public enum touchSensorModeList { RAWMODE = 0x00, BOOLEAN_MODE = 0x20 };

        private touchSensorModeList sensorMode;

        public TouchSensor()
        {
            this.state = SensorInfo.SensorConnectionStateList.DISCONECTED;
            this.sensorType = SensorInfo.SensorTypeList.SWITCH;
            this.sensorMode = touchSensorModeList.RAWMODE;
        }

        public TouchSensor(SerialCommunication communication, SensorInfo.SensorPortList portId)
        {
            this.sc = communication;

            if (sc.STATE == SerialCommunicationInfo.CONNECTION_STATE.CONNECTED)
            {
                this.state = SensorInfo.SensorConnectionStateList.CONNECTED;
            }

            this.sensorType = SensorInfo.SensorTypeList.SWITCH;
            this.sensorMode = touchSensorModeList.RAWMODE;

            this.sensorPort = portId;
            this.port = new Byte[] { (byte)portId };
        }

        public TouchSensor(SerialCommunication communication, SensorInfo.SensorPortList portId, touchSensorModeList listenMode)
        {
            this.sc = communication;

            if (sc.STATE == SerialCommunicationInfo.CONNECTION_STATE.CONNECTED && installSensor())
            {
                this.state = SensorInfo.SensorConnectionStateList.CONNECTED;
            }

            this.sensorType = SensorInfo.SensorTypeList.SWITCH;
            this.sensorMode = listenMode;

            this.sensorPort = portId;
            this.port = new Byte[] { (byte)portId };
        }

        private Boolean installSensor()
        {
            Byte[] header = { 0x80, 0x05 };

            Byte[] message = Utils.ConcatBytes(header,
                                Utils.ConcatBytes(this.port,
                                    Utils.ConcatBytes(new Byte[]{ (byte)this.sensorType }, new Byte[]{ (byte)this.sensorMode })
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

            return false;
        }

        public Boolean isPressed()
        {
            return true;
        }
    }
}
