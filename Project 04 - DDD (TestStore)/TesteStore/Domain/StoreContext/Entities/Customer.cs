using FluentValidator;
using System.Collections.Generic;
using TesteStore.Domain.StoreContext.ValueObjects;

namespace TesteStore.Domain.StoreContext.Entities
{
    public class Customer : Notifiable
    {

        private readonly List<Address> _addresses;

        public Customer(
            Name name,
            Document document,
            Email email,
            Phone phone)
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this.Phone = phone;
            this._addresses = new List<Address>();
        }
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public void AddAddress(Address address)
        {
            // validar o endereço
            // Adicionar o endereço
            this._addresses.Add(address);
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }

    }

    
}
