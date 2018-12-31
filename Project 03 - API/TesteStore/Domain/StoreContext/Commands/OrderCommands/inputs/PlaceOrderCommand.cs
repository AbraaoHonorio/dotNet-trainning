using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using TesteStore.Shared.Command;

namespace Domain.StoreContext.Commands.OrderCommands.inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            this.OrderItems = new List<OrderItemCommand>();
        }
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool IsValid()
        {

            AddNotifications(new ValidationContract()
                     .Requires()
                     .HasMinLen(this.Customer.ToString(), 36, "Customer", "o Guid do Customer deve conter pelo menos 3 caracteres")
                     .IsGreaterThan(this.OrderItems.Count, 0, "items", "Nenhum item do pedido foi encontrado")
                     
               );

            return Valid;
        }
    }
    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }

}
