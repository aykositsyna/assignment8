using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment8
{
    internal class Customer
    {
        public string FullName;
        public byte GentleRate;
        public GentleSmartphone Smartphone;
        public Transformator TransformModule;

        public Customer(string name, byte _gentleRate, GentleSmartphone _smartphone, Transformator _transformModule)
        {
            FullName = name;
            GentleRate = _gentleRate;
            Smartphone = _smartphone;
            TransformModule = _transformModule;
        }
    }
}
