using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXTLib
{
    public class Brick
    {
        private Int32 firmwareMajorVersion = -1;
        private Int32 firmwareMinorVersion = -1;
        private Int32 protocolMajorVersion = -1;
        private Int32 protocolMinorVersion = -1;
        private String brickName = null;

        private SerialCommunication sc;

        private Peripherals.Bluetooth bluetooth;
        private Peripherals.Motor motor_a;
        private Peripherals.Motor motor_b;
        private Peripherals.Motor motor_c;
        private Peripherals.Sensors.Sensor sensor_1;
        private Peripherals.Sensors.Sensor sensor_2;
        private Peripherals.Sensors.Sensor sensor_3;
        private Peripherals.Sensors.Sensor sensor_4;

        public Brick(SerialCommunication communication)
        {
            this.sc = communication;

            if (this.sc.STATE == SerialCommunicationInfo.CONNECTION_STATE.CONNECTED)
            {
                GetVersion();
                GetDeviceInfo();

                motor_a = new Peripherals.Motor();
                motor_b = new Peripherals.Motor();
                motor_c = new Peripherals.Motor();
                sensor_1 = new Peripherals.Sensors.Sensor();
                sensor_2 = new Peripherals.Sensors.Sensor();
                sensor_3 = new Peripherals.Sensors.Sensor();
                sensor_4 = new Peripherals.Sensors.Sensor();
            }
            // Afiliarse a eventos
        }

        private Boolean GetVersion()
        {
            if (sc.STATE == SerialCommunicationInfo.CONNECTION_STATE.CONNECTED)
            {

                Byte[] message = { 0x01, 0x88 };
                Byte[] response = sc.Communication(message);

                if (response != null)
                {
                    try
                    {
                        if (response[0] == 0x02 && response[1] == message[1] && response[2] == 0x00)
                        {
                            FIRMWARE_MAJORVERSION = response[6];
                            FIRMWARE_MINORVERSION = response[5];
                            PROTOCOL_MAJORVERSION = response[4];
                            PROTOCOL_MINORVERSION = response[3];
                            return true;
                        }
                    }
                    catch
                    { }
                }
            }

            return false;
        }

        private Boolean GetDeviceInfo()
        {
            if (this.sc.STATE == SerialCommunicationInfo.CONNECTION_STATE.CONNECTED)
            {
                Byte[] message = { 0x01, 0x9B };
                Byte[] response = this.sc.Communication(message);

                if (response != null)
                {
                    try
                    {
                        if (response[0] == 0x02 && response[1] == message[1] && response[2] == 0x00)
                        {
                            // Aqui hay algun tipo de error
                            this.brickName = Utils.getString(Utils.SubBytes(response, 3, 14));
                            this.BLUETOOTH = new Peripherals.Bluetooth(Utils.SubBytes(response, 18, 6));
                            //Acabar con el soporte

                            return true;
                        }
                    }
                    catch
                    { }
                }
            }

            return false;
        }

        public Boolean SetName(String name)
        {
            if (this.sc.STATE == SerialCommunicationInfo.CONNECTION_STATE.CONNECTED)
            {
                Byte[] nombre;
                if (name.Length > 15)
                    nombre = Utils.StringToBytes(name.Substring(0, 15));
                else
                    nombre = Utils.StringToBytes(name);

                Byte[] message = Utils.ConcatBytes(new Byte[] { 0x01, 0x98 }, Utils.ConcatBytes(nombre, new Byte[] { 0x00 }));
                Byte[] response = this.sc.Communication(message);

                if (response != null)
                {
                    try
                    {
                        if (response[0] == 0x02 && response[1] == message[1] && response[2] == 0x00)
                        {
                            GetDeviceInfo();
                            return true;
                        }
                    }
                    catch
                    { }
                }
            }

            return false;
        }

        public void AddMotorA()
        {
            this.motor_a = new Peripherals.Motor(this.sc, Peripherals.MotorInfo.MotorPortList.PORT_A);
        }

        public void AddMotorB()
        {
            this.motor_b = new Peripherals.Motor(this.sc, Peripherals.MotorInfo.MotorPortList.PORT_B);
        }

        public void AddMotorC()
        {
            this.motor_c = new Peripherals.Motor(this.sc, Peripherals.MotorInfo.MotorPortList.PORT_C);
        }

        public void AddSensor1(Peripherals.Sensors.SensorInfo.SensorTypeList sensorType)
        {
            switch (sensorType)
            {
                case Peripherals.Sensors.SensorInfo.SensorTypeList.SWITCH:
                    this.sensor_1 = new Peripherals.Sensors.TouchSensor(this.sc, Peripherals.Sensors.SensorInfo.SensorPortList.PORT_1, Peripherals.Sensors.TouchSensor.touchSensorModeList.RAWMODE);
                    break;
                default:
                    return;
            }
        }

        public void AddSensor2(Peripherals.Sensors.SensorInfo.SensorTypeList sensorType)
        {
            switch (sensorType)
            {
                case Peripherals.Sensors.SensorInfo.SensorTypeList.SWITCH:
                    this.sensor_2 = new Peripherals.Sensors.TouchSensor(this.sc, Peripherals.Sensors.SensorInfo.SensorPortList.PORT_2, Peripherals.Sensors.TouchSensor.touchSensorModeList.RAWMODE);
                    break;
                default:
                    return;
            }
        }

        public void AddSensor3(Peripherals.Sensors.SensorInfo.SensorTypeList sensorType)
        {
            switch (sensorType)
            {
                case Peripherals.Sensors.SensorInfo.SensorTypeList.SWITCH:
                    this.sensor_3 = new Peripherals.Sensors.TouchSensor(this.sc, Peripherals.Sensors.SensorInfo.SensorPortList.PORT_3, Peripherals.Sensors.TouchSensor.touchSensorModeList.RAWMODE);
                    break;
                default:
                    return;
            }
        }

        public void AddSensor4(Peripherals.Sensors.SensorInfo.SensorTypeList sensorType)
        {
            switch (sensorType)
            {
                case Peripherals.Sensors.SensorInfo.SensorTypeList.SWITCH:
                    this.sensor_4 = new Peripherals.Sensors.TouchSensor(this.sc, Peripherals.Sensors.SensorInfo.SensorPortList.PORT_4, Peripherals.Sensors.TouchSensor.touchSensorModeList.RAWMODE);
                    break;
                default:
                    return;
            }
        }

        public String FIRMWARE_VERSION
        {
            get
            {
                return firmwareMajorVersion.ToString() + "." + firmwareMinorVersion.ToString();
            }
        }

        public Int32 FIRMWARE_MAJORVERSION
        {
            get { return this.firmwareMajorVersion; }
            set
            {
                if (value >= 0 || value < 999)
                    this.firmwareMajorVersion = value;
                else
                    this.firmwareMajorVersion = 0;
            }
        }

        public Int32 FIRMWARE_MINORVERSION
        {
            get { return this.firmwareMinorVersion; }
            set
            {
                if (value >= 0 || value < 999)
                    this.firmwareMinorVersion = value;
                else
                    this.firmwareMinorVersion = 0;
            }
        }

        public String PROTOCOL_VERSION
        {
            get
            {
                return protocolMajorVersion.ToString() + "." + protocolMinorVersion.ToString();
            }
        }

        public Int32 PROTOCOL_MAJORVERSION
        {
            get { return this.protocolMajorVersion; }
            set
            {
                if (value >= 0 || value < 999)
                    this.protocolMajorVersion = value;
                else
                    this.protocolMajorVersion = 0;
            }
        }

        public Int32 PROTOCOL_MINORVERSION
        {
            get { return this.protocolMinorVersion; }
            set
            {
                if (value >= 0 || value < 999)
                    this.protocolMinorVersion = value;
                else
                    this.protocolMinorVersion = 0;
            }
        }

        public String NAME
        {
            get { return this.brickName; }
        }

        // Comunicación del Brick
        public SerialCommunication COMMUNICATION
        {
            get { return this.sc; }
        }

        // Perifericos del Brick
        public Peripherals.Bluetooth BLUETOOTH
        {
            get { return this.bluetooth; }
            set { this.bluetooth = value; }
        }

        public Peripherals.Motor MOTOR_A
        {
            get { return this.motor_a; }
            //set { this.motor_a = value; }
        }

        public Peripherals.Motor MOTOR_B
        {
            get { return this.motor_b; }
            //set { this.motor_b = value; }
        }

        public Peripherals.Motor MOTOR_C
        {
            get { return this.motor_c; }
            //set { this.motor_c = value; }
        }

        public Peripherals.Sensors.Sensor SENSOR_1
        {
            get { return this.sensor_1; }
            //set { this.sensor_1 = value; }
        }

        public Peripherals.Sensors.Sensor SENSOR_2
        {
            get { return this.sensor_2; }
            //set { this.sensor_2 = value; }
        }

        public Peripherals.Sensors.Sensor SENSOR_3
        {
            get { return this.sensor_3; }
            //set { this.sensor_3 = value; }
        }

        public Peripherals.Sensors.Sensor SENSOR_4
        {
            get { return this.sensor_4; }
            //set { this.sensor_4 = value; }
        }
    }
}
