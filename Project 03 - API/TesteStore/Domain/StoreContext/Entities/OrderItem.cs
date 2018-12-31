using FluentValidator;
using TesteStore.Shared.Entities;

namespace TesteStore.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Price = product.Price;

            if (product.QuantityOnHand < quantity)
                AddNotification("Quantity", "Prooduto fora de estoque");

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        
    }
}
