using System;
using TesteStore.Shared.Command;

namespace TesteStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{ 
   public class CreateCustomerCommandResult : ICommandResult
   {
        public CreateCustomerCommandResult(bool success, string message, object data)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

}