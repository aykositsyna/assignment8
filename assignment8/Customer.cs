using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment8;
using static Names;

namespace assignment8
{
    internal class Customer
    {
        public string FullName;
        public byte GentleRate;
        public GentleSmartphone Smartphone;
        public Transformator TransformModule;

        public Customer(string name, byte _gentleRate)
        {
            FullName = name;
            GentleRate = _gentleRate;
        }

        public Customer()
        {
            Random random = new Random();
            int gentleRateInt = random.Next(0, 255);
            GentleRate = Convert.ToByte(gentleRateInt);
            //get random name from enum Names
            Array values1 = Enum.GetValues(typeof(Names));
            string randomName = ((Names)values1.GetValue(random.Next(values1.Length))).ToString();

        }
    }
}
