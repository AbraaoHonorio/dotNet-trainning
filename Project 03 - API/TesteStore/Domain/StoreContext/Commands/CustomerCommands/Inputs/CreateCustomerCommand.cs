using FluentValidator;
using FluentValidator.Validation;
using TesteStore.Shared.Command;

namespace TesteStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{

   public class CreateCustomerCommand : Notifiable, ICommand

    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public bool IsValid()
        {
            AddNotifications(new ValidationContract()
                     .Requires()
                     .HasMinLen(FirstName, 3, "FirstName", "Nome deve conter pelo menos 3 caracteres")
                     .HasMaxLen(FirstName, 50, "FirstName", "Nome deve conter no máximo 50 caracteres")
                     .HasMinLen(LastName, 3, "LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                     .HasMaxLen(LastName, 150, "LastName", "Sobrenome deve conter no máximo 150 caracteres")
                     .IsEmail(Email,"Email", "O E-mail é invalido")
                     .HasLen(Document, 11, "Document", "Cpf inválido")
               );

            return Valid;
        }
    }


  
}
