using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment8
{
    internal class GentleSmartphone
    {
        public int SerialNumber;
        public TacticleSensor Sensor;

        public GentleSmartphone(int _serialNumber,  byte sensorSensitivity)
        {
            SerialNumber = _serialNumber;
            Sensor = new TacticleSensor(sensorSensitivity);
        }
    }
}
