using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using TesteStore.Domain.StoreContext.ValueObjects;

namespace TesteStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        private CreateCustomerCommand _ValidCreateCustomer;
        private CreateCustomerCommand _inValidCreateCustomer;

        public CreateCustomerCommandTests()
        {
            this._ValidCreateCustomer = new CreateCustomerCommand();
            this._ValidCreateCustomer.FirstName = "Abraão";
            this._ValidCreateCustomer.LastName = " Állyson";
            this._ValidCreateCustomer.Document = "10468306005";
            this._ValidCreateCustomer.Email = "abraao@gmail.com";
            this._ValidCreateCustomer.Phone = "(83) 98747-7358";


            this._inValidCreateCustomer = new CreateCustomerCommand();
            this._inValidCreateCustomer.FirstName = "Abraão";
            this._inValidCreateCustomer.LastName = " aa";
            this._inValidCreateCustomer.Document = "11122233344";
            this._inValidCreateCustomer.Email = "abraao@abraao";
            this._inValidCreateCustomer.Phone = "(03) 0000-7358";

        }

        
        [TestMethod]
        public void ShouldReturnNotificationWhenCreateCustomerCommandIsValid()
        {
            Assert.AreEqual(true, this._ValidCreateCustomer.IsValid());
            Assert.AreEqual(0, _ValidCreateCustomer.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenCreateCustomerCommandIsNotValid()
        {
            Assert.AreEqual(false, this._inValidCreateCustomer.IsValid());
            Assert.AreNotEqual(0, _inValidCreateCustomer.Notifications.Count);
        }
    }
}