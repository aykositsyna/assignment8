using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static assignment8.GentleSmartphone;
using static assignment8.Customer;
using static TransformatorType;

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

        public void SaleSmartphone()
        {
            List<GentleSmartphone> selectedSmartphones = new List<GentleSmartphone>();
            foreach (Customer customer in Customers)
            {
                foreach(GentleSmartphone smartphone in Smartphones)
                {
                    bool firstCondition = (customer.GentleRate * 1.5) <= smartphone.Sensor.Sensitivity;
                    bool secondCondition = customer.GentleRate <= (smartphone.Sensor.Sensitivity * 2);
                    bool firstConditionWithMult = (customer.GentleRate * 1.5) <= (smartphone.Sensor.Sensitivity * 2);
                    bool secondConditionWithMult = customer.GentleRate <= (smartphone.Sensor.Sensitivity * 2 * 2);
                    bool firstConditionWithDiv = (customer.GentleRate * 1.5) <= (smartphone.Sensor.Sensitivity / 2);
                    bool secondConditionWithDiv = customer.GentleRate <= (smartphone.Sensor.Sensitivity * 2 / 2);
                    if ( firstCondition && secondCondition )
                    {
                        customer.Smartphone = smartphone;
                        selectedSmartphones.Add(smartphone);
                        break;
                    }
                    else if( firstConditionWithMult && secondConditionWithMult)
                    {
                        customer.Smartphone = smartphone;
                        customer.TransformModule = Multiplier;
                        selectedSmartphones.Add(smartphone);
                        break;
                    }
                }
            }

            Smartphones = Smartphones.Except(selectedSmartphones).ToList();

        }
    }
}
