using FluentValidator;


namespace TesteStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {
        public OrderItem(Product product, decimal quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Price = product.Price;

            if (product.QuantityOnHand < quantity)
                AddNotification("Quantity", "Prooduto fora de estoque");
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        
    }
}
