using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteStore.Domain.StoreContext.Entities;
using TesteStore.Domain.StoreContext.ValueObjects;
using TesteStore.Domain.StoreContext.Handlers;
using Tests.Mocks;
using TesteStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;

namespace TesteStore.Tests.Handlers 
{
    [TestClass]
    public class CustomerHandlerTests
    {

        private CreateCustomerCommand _ValidCreateCustomer;

        [TestMethod]
        public void ShouldRegisterCustomerWhenHandlerIsValid()
        {
            this._ValidCreateCustomer = new CreateCustomerCommand();
            this._ValidCreateCustomer.FirstName = "Abraão";
            this._ValidCreateCustomer.LastName = " Állyson";
            this._ValidCreateCustomer.Document = "10468306005";
            this._ValidCreateCustomer.Email = "abraao@gmail.com";
            this._ValidCreateCustomer.Phone = "(83) 98747-7358";


            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(this._ValidCreateCustomer);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.Valid);
        }
       
    }
}
