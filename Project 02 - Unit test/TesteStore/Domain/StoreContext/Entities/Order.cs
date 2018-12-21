using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteStore.Domain.StoreContext.Entities
{
    class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        // to Place An Order
        public void Place() { }
        
    }
}
