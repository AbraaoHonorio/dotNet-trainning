using System;
using TesteStore.Domain.StoreContext.Enums;
using TesteStore.Shared.Entities;

namespace TesteStore.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            // validação de pedido
            Status = EDeliveryStatus.Shipped;
        }
        public void Cancel()
        {
            // validação - Se o status já estiver entregue, não se pode cancelar
            Status = EDeliveryStatus.Canceled;
        }
    }

}
