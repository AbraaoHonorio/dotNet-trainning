using System;
using System.Collections.Generic;

namespace TesteStore.Domain.StoreContext.Entities
{
    public class Customer 
    {

        private readonly List<string> _addresses;

        public Customer(
            string name,
            string document,
            string email,
            string phone,
            List<string> addresses)
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this.Phone = phone;
            this._addresses = addresses;
        }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<string> Addresses => _addresses.ToArray();
    }

    
}
