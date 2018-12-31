using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteStore.Domain.StoreContext.Enums;
using TesteStore.Shared.Entities;

namespace TesteStore.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            this.Customer = customer;
            this.CreateDate = DateTime.Now;
            this.Status = EOrderStatus.Created;
            this._items = new List<OrderItem>();
            this._deliveries = new List<Delivery>();

        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();



        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("Order", $"Prduto {product.Title} nãoo tem {quantity} itens em estoque");
            else
            {
                var item = new OrderItem(product, quantity);
                this._items.Add(item);
            }
                
        }
        public void AddDelivery(Delivery delivery)
        {
            //valida delivery
            this._deliveries.Add(delivery);
        }

        // adiciona um pedido a uma ordem
        public void Place()
        {
            //Gera oo número do pedido
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (this._items.Count == 0)
                AddNotification("Order", "Este pedido não possuo itens");
        }
        //Efuta o pagamento do pedido
        public void Pay()
        {
            this.Status = EOrderStatus.Paid;
          
        }

        // Envia o pedido
        public void Ship()
        {
            var deliveries = new List<Delivery>();

            // validação - A cada 5 produtos é uma entrega 
            var count = 1;
            foreach(var item in _items)
            {
                if(count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;

            }
            // Envia todas as entregas
            deliveries.ForEach(d => d.Ship());
            
            // Adiciona as entregas ao pedido
            deliveries.ForEach(d => this.AddDelivery(d));

        }

        public void Cancel()
        {
            this.Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}
