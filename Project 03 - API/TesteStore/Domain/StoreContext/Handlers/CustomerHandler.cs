using Domain.StoreContext.Commands.CustomerCommands.Outputs;
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

            if (this._repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");


            // Verificar se o E-mail já existe na base
            if (this._repository.CheckEmail(command.Email))
                AddNotification("Email", "Este E-mail já está em uso");


            // Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var phone = new CellPhone(command.Phone);

            // Criar a entidade
            var customer = new Customer(name, document, email, phone);

            // Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(phone.Notifications);
            AddNotifications(customer.Notifications);
            if (Invalid)
            {
                return new CommandResult(
                    false, 
                    "Por favor, corrija os campos abaixo",
                    Notifications);
            }
            // Persistir o cliente
            this._repository.Save(customer);

            // Enviar um E-mail de boas vindas
            this._emailService.Send(customer.Email.Address, "abraao@gmail.com", "Seja Bem-vindo", "Seja bem-vindo a Teste Store =D");
            AddNotifications(customer.Notifications);
            // Retornar o resultado para tela
            return new CommandResult(true, "Bem vindo ao Testo Store",
                new 
                {
                    customer.Id,
                    Name = customer.Name.ToString(),
                    Email = customer.Email.Address
                });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
