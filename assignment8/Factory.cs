using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static assignment8.GentleSmartphone;
using static assignment8.Customer;

namespace assignment8
{
    internal class Factory
    {
        public List<GentleSmartphone> Smartphones;
        public List<Customer> Customers;

        public Factory( List<Customer> customers)
        {
            Random random = new Random();
            Smartphones = new List<GentleSmartphone>();
            for (int i = 0; i < 10; i++)
            {
                int sensitivityInt = random.Next(50, 200);
                byte sensitivity = Convert.ToByte(sensitivityInt);
                int serialNumber = random.Next(100000, 999999);
                Smartphones[i] = new GentleSmartphone(serialNumber, sensitivity);
            }

            Customers = customers;


        }

        public static void SaleSmartphone()
        {

        }
    }
}
