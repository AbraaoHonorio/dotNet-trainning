using FluentValidator;
using System;
using TesteStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using TesteStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using TesteStore.Domain.StoreContext.Entities;
using TesteStore.Domain.StoreContext.ValueObjects;

namespace TesteStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);

        bool CheckEmail(string email);

        void Save(Customer customer);
    }
}

