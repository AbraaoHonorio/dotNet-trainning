using System;

namespace Solid.Models
{
    public class Customer
    {
        public Customer(Guid id, string name, string document)
        {
            this.Id = id;
            this.Name = name;
            this.Document = document;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
