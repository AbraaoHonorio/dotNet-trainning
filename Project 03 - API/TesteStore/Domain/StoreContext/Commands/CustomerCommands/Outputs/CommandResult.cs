using TesteStore.Shared.Command;

namespace Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message, object data)
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
