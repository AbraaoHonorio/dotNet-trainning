using System;
using System.Collections.Generic;
using System.Text;

namespace TesteStore.Domain.StoreContext.Entities
{
    class OrderItem
    {

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}
