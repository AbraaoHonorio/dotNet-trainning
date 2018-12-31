using FluentValidator;
using System;
using TesteStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using TesteStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using TesteStore.Domain.StoreContext.Entities;
using TesteStore.Domain.StoreContext.Repositories;
using TesteStore.Domain.StoreContext.Services;
using TesteStore.Domain.StoreContext.ValueObjects;
using TesteStore.Shared.Command;

namespace TesteStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {

        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            this._repository = repository;
            this._emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //To do 
            // Verficar se o CPF já existe no BD

            // Verificar se o CPF já existe na base
            if (this._repository.CheckDocument(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso");
                return null;
            }


            // Verificar se o E-mail já existe na base
            if (this._repository.CheckEmail(command.Email))
                AddNotification("Email", "Este E-mail já está em uso");


            // Criar os VOs

            var customer = new Customer(new Name(command.FirstName,command.LastName),new Document("10468306005"),
                                        new Email("abraao@gmail.com"), new CellPhone("(83) 98753-2222"));
            
            if (Invalid)
                return null;
            // Persistir o cliente
            this._repository.Save(customer);

            // Enviar um E-mail de boas vindas
            this._emailService.Send(customer.Email.Address, "abraao@gmail.com", "Seja Bem-vindo", "Seja bem-vindo a Teste Store =D");
            AddNotifications(customer.Notifications);
            // Retornar o resultado para tela
            return new CreateCustomerCommandResult(customer.Id, customer.Name.ToString(), customer.Email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
