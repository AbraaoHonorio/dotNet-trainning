using System;
using System.Collections.Generic;
using System.Text;
using TesteStore.Domain.StoreContext.Entities;
using TesteStore.Domain.StoreContext.Queries;
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

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult GetById(Guid IdParameter)
        {
            throw new NotImplementedException();
        }

        public ListCustomerQueryResult GetCustomerOrdersCount(string document)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
           
        }
    }
}
