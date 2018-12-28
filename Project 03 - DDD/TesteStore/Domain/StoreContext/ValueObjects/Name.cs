using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {

        public ValidationContract Contract { get; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(firstName, 3, "FirstName", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(firstName, 50, "FirstName", "Nome deve conter no máximo 50 caracteres")
                .HasMinLen(lastName, 3, "LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                .HasMinLen(firstName, 150, "LastName", "Sobrenome deve conter no máximo 150 caracteres")
          );


        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

       
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
