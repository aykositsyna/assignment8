using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment8
{
    internal class Transformator
    {
        public int SerialNumber;
        public TransformatorType TransformType;

        public Transformator(int _serialNumber, TransformatorType _transformType)
        {
            SerialNumber = _serialNumber;
            TransformType = _transformType;
        }
    }
}
