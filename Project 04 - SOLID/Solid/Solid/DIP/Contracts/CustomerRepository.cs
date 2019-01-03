using Solid.Models;
using System;


namespace Solid.DIP.Contracts
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Save(Customer customer)
        {
            Console.WriteLine(" ->>>" + customer.ToString());
        }
    }
}
