
using System;

namespace TesteStore.Domain.StoreContext.Queries
{
    public class GetCustomerQueryResult
    {
        public Guid id { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }

    }
}
