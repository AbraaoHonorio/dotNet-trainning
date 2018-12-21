using System;
using System.Collections.Generic;
using System.Text;

namespace TesteStore.Domain.StoreContext.Entities
{
    class Delivery
    {
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public string Status { get; private set; }
    }
}
