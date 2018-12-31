using System;
using TesteStore.Shared.Command;

namespace TesteStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{ 
   public class CreateCustomerCommandResult : ICommandResult
   {

        public CreateCustomerCommandResult() { }
        public CreateCustomerCommandResult(Guid id, string name, string email)
        {
            this.id = id;
            this.Name = name;
            this.Email = email;
        }

        public Guid id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
       

   }

}