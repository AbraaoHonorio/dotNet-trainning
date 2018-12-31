using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;
using TesteStore.Domain.StoreContext.Enums;
using TesteStore.Shared.Command;

namespace TesteStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
   public class AddAddressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get;  set; }
        public string Number { get;  set; }
        public string Complement { get;  set; }
        public string District { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
        public string ZipCode { get;  set; }
        public EAddressType Type { get;  set; }

       
        public bool IsValid()
        {
            return Valid;
        }
    }
}
