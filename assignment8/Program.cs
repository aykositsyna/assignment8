using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static assignment8.Customer;
using static assignment8.Factory;

namespace assignment8
{
    public class Assignment8
    {
        public static void Main(string[] args)
        {
            List < Customer > customers = new List<Customer>();
            for (int i = 0; i < 10; i++)
            {
                customers.Add(new Customer());
            }

            Factory factory = new Factory(customers);

            factory.PrintPhones();
            factory.PrintCustomers(false);
            factory.SaleSmartphone();
            factory.PrintCustomers(true);
            factory.PrintPhones();
            factory.ClearSmartphones();
        }

    }
}
