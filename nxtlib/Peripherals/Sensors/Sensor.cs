using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXTLib.Peripherals.Sensors
{
    public class SensorInfo
    {
        public enum SensorConnectionStateList { CONNECTED, DISCONECTED };

        public enum SensorTypeList
        {
            NO_SENSOR = 0x00, SWITCH = 0x01, TEMPERATURE = 0x02, REFLECTION = 0x03, ANGLE = 0x04,
            LIGHT_ACTIVE = 0x05, LIGHT_INACTIVE = 0x06, SOUNDDB = 0x07, SOUNDDBA = 0x08, CUSTOM = 0x09, 
            LOWSPEED = 0x0A, LOWSPEED_9V = 0x0B, NO_OF_SENSOR_TYPES = 0x0C
        };
        public enum SensorModeList
        {
            RAWMODE = 0x00, BOOLEAN_MODE = 0x20, TRANSITIONCNTMODE = 0x40, PERIODCOUNTERMODE = 0x60,
            PCTFULLSCALEMODE = 0x80, CELSIUSMODE = 0xA0, FAHRENHEITMODE = 0xC0, ANGLESTEPMODE = 0xE0,
            SLOPEMASK = 0x1F, MODEMASK = 0xE0
        };

        public enum SensorPortList { PORT_1 = 0x00, PORT_2 = 0x01, PORT_3 = 0x02, PORT_4 = 0x03, NONE };
    }

    public class Sensor
    {
        protected SensorInfo.SensorConnectionStateList state;
        protected SerialCommunication sc;

        protected SensorInfo.SensorPortList sensorPort;
        protected Byte[] port;

        protected SensorInfo.SensorTypeList sensorType;

        public Sensor()
        {
            this.state = SensorInfo.SensorConnectionStateList.DISCONECTED;
            this.sensorType = SensorInfo.SensorTypeList.NO_SENSOR;
            this.sensorPort = SensorInfo.SensorPortList.NONE;
        }

        #region Delegados
        public SensorInfo.SensorConnectionStateList STATE
        {
            get { return this.state; }
        }

        public SensorInfo.SensorPortList PORT
        {
            get { return this.sensorPort; }
        }

        public SensorInfo.SensorTypeList SENSORTYPE
        {
            get { return this.sensorType; }
        }
        #endregion
    }
}
