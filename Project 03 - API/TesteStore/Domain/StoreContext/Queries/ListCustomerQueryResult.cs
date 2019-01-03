using System;


namespace TesteStore.Domain.StoreContext.Queries
{
    public class ListCustomerQueryResult
    {
        public Guid id { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public int Orders { get; set; }
    }
}