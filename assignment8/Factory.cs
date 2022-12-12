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
                Smartphones.Add(new GentleSmartphone(serialNumber, sensitivity));
            }

            Customers = customers;


        }

        public void SaleSmartphone()
        {
            List<GentleSmartphone> selectedSmartphones = new List<GentleSmartphone>();
            foreach (Customer customer in Customers)
            {
                TrySmartphones(customer, selectedSmartphones);
            }
            Console.WriteLine();
        }

        private void TrySmartphones(Customer customer, List<GentleSmartphone> selectedSmartphones)
        {
            int smartphoneIndex = Smartphones.FindIndex(smartphone =>
            {
                if (CompareSensitivity(customer, smartphone, selectedSmartphones))
                    return true;
                return false;
            });

            if (smartphoneIndex < 0)
            {
                smartphoneIndex = Smartphones.FindIndex(smartphone =>
                {
                    if (CompareSensitivity(customer, smartphone, selectedSmartphones, Multiplier))
                      return true;
                    return false;
                });
            }

            if (smartphoneIndex < 0)
            {
                smartphoneIndex = Smartphones.FindIndex(smartphone =>
                {
                    if (CompareSensitivity(customer, smartphone, selectedSmartphones, Divider))
                        return true;
                    return false;
                });
            }

            if (smartphoneIndex >= 0)
            {
                Console.WriteLine("Select smartphone {0} for customer {1}", Smartphones[smartphoneIndex].SerialNumber, customer.FullName);
                Smartphones.RemoveAt(smartphoneIndex);

            }
            else
            {
                Console.WriteLine("No smartphones for customer {0}", customer.FullName);
            }

        }

        private bool CompareSensitivity(
            Customer customer,
            GentleSmartphone smartphone,
            List<GentleSmartphone> selectedSmartphones,
            TransformatorType? transType = null
        )
        {
            Random random = new Random();
            double cofficient = 1;
            if (transType == Multiplier)
            {
                cofficient = 2;
            }
            if (transType == Divider)
            {
                cofficient = 0.5;
            }
 
            bool firstCondition = (customer.GentleRate * 1.5) <= (smartphone.Sensor.Sensitivity * cofficient);
            bool secondCondition = customer.GentleRate <= (smartphone.Sensor.Sensitivity * 2 * cofficient);

            if (firstCondition && secondCondition)
            {
                if (cofficient != 1)
                {
                    int serialNum = random.Next(100, 999);
                    customer.TransformModule = new Transformator(serialNum, (TransformatorType)transType);
                }
                customer.Smartphone = smartphone;
                selectedSmartphones.Add(smartphone);
                return true;
            }
            return false;
        }

        public void PrintCustomers(bool printSmartphones)
        {
            Console.WriteLine("Customers:");
            foreach (Customer customer in Customers)
            {
                Console.Write(
                    "Name: {0},\t Gentle rate: {1},\t ",
                    customer.FullName, customer.GentleRate
                    );
                if (printSmartphones)
                {
                    if(customer.Smartphone != null)
                    {
                        Console.Write("Smartphone: {0}", customer.Smartphone.SerialNumber);
                    }
                    else
                    {
                        Console.Write("No smartphone:(");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void PrintPhones()
        {
            Console.WriteLine("Smartphones:");
            foreach (GentleSmartphone smartphone in Smartphones)
            {
                Console.WriteLine(
                    "Serial number: {0},\t Sensitivity: {1}",
                    smartphone.SerialNumber, smartphone.Sensor.Sensitivity
                );
            }

            Console.WriteLine();
        }

        public void ClearSmartphones()
        {
            Smartphones.Clear();
            Console.WriteLine("Collection of smartphones is cleared");
        }
    }
}
