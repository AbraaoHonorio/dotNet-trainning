using System;
using System.Collections.Generic;
using TesteStore.Domain.StoreContext.Entities;
using TesteStore.Domain.StoreContext.Queries;

namespace TesteStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);

        bool CheckEmail(string email);

        void Save(Customer customer);

        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult Get(Guid id);


    }
}

