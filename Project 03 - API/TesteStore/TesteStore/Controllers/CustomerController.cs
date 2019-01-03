using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TesteStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using TesteStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using TesteStore.Domain.StoreContext.Entities;
using TesteStore.Domain.StoreContext.Handlers;
using TesteStore.Domain.StoreContext.Queries;
using TesteStore.Domain.StoreContext.Repositories;
using TesteStore.Domain.StoreContext.ValueObjects;
using TesteStore.Shared.Command;

namespace Api.Controllers
{
    [Route("api")]
    public class CustomerController : Controller
    {
        public readonly ICustomerRepository _repository;
        private readonly CustomerHandler _hadler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            this._repository = repository;
            this._hadler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Duration = 10)]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return this._repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return this._repository.Get(id);
        }

        [HttpGet]
        [ApiExplorerSettings(GroupName = "v2")]
        [Route("v2/customers/{document}")]
        public GetCustomerQueryResult GetByDocument(Guid document)
        {
            return _repository.Get(document);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {

            var name = new Name("Abrao", "allysson");
            var document = new Document("123456789");
            var email = new Email("contado@abraao.com.br");
            var phone = new CellPhone("5583988887777");
            var customer = new Customer(name, document, email, phone);
            var mouse = new Product("Mouse", "O Mouse óptico wireless",
                                    "Mouse.png", 59.90M, 20);
            var teclado = new Product("Teclado", " O teclado de tamanho normal sem fio",
                                    "Teclado.png", 100.00M, 20);
          
            var order = new Order(customer);
            order.AddItem(mouse, 5);
            order.AddItem(teclado, 5);
            var orders = new List<Order>
            {
                order
            };

            return orders;
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody] CreateCustomerCommand customerCommand)
        {

            var result =  this._hadler.Handle(customerCommand);
            return result;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand customerCommand)
        {
            var name = new Name(customerCommand.FirstName, customerCommand.LastName);
            var document = new Document(customerCommand.Document);
            var email = new Email(customerCommand.Email);
            var phone = new CellPhone(customerCommand.Phone);
            var customer = new Customer(name, document, email, phone);

            return customer;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public ActionResult<object> Delete(Guid id)
        {
            return new { message = $"Cliente {id} Deletado com sucesso" };
        }
    }
}