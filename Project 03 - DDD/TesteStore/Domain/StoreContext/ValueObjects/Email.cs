using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {

        public ValidationContract Contract { get; }

        public Email(string address)
        {
            this.Address = address;

            AddNotifications(new ValidationContract()
              .IsEmail(Address, "Email", "Email inválido")
          );
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return this.Address;
        }
    }
}
