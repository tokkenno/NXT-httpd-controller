using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXTLib.Peripherals
{
    public class Bluetooth
    {
        private Byte[] lap;
        private Byte uap;
        private Byte[] nap;

        public Bluetooth (Byte[] address)
        {
            if (address.Length != 6)
                throw new Exception("The Bluetooth Address only can have 48 bits (6 Bytes).");
            
            lap = new Byte[3];
            nap = new Byte[2];

            lap[0] = address[0];
            lap[1] = address[1];
            lap[2] = address[2];
            uap = address[3];
            nap[0] = address[4];
            nap[1] = address[5];
        }

        public Byte[] LAP
        {
            get { return this.lap; }
        }

        public Byte UAP
        {
            get { return this.uap; }
        }

        public Byte[] NAP
        {
            get { return this.nap; }
        }

        public String ADDRESS
        {
            get { return Utils.BytesToString(lap) + '-' + Utils.ByteToString(uap) + '-' + Utils.BytesToString(nap); }
        }
    }
}
