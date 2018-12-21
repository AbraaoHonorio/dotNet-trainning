using System;
using System.Collections.Generic;
using System.Text;

namespace TesteStore.Domain.StoreContext.Entities
{
    class Product
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnHand { get; private set; }
    }
}
