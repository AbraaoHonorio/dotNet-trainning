using System;
using System.Collections.Generic;
using System.Text;
using TesteStore.Domain.StoreContext.Entities;
using TesteStore.Domain.StoreContext.Repositories;

namespace Tests.Mocks
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {
           
        }
    }
}
