using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TesteStore.Domain.StoreContext.Entities;
using TesteStore.Domain.StoreContext.Enums;
using TesteStore.Domain.StoreContext.ValueObjects;

namespace TesteStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Customer _customer;
        private Order _order;
        private Product _mouse;
        private Product _monitor;
        private Product _chair;
        private Product _keyboard;


        public OrderTests()
        {
            var name = new Name("Abraao", "Allysson dos Santos Honório");
            var document = new Document("228.750.270-00");
            var email = new Email("abraao.allyson@eng.ci.ufpb.br");
            var phone = new CellPhone("(83) 98747 - 7358");
            this._customer = new Customer(name, document, email, phone);

            this._order = new Order(this._customer);

            this._mouse = new Product("Mouse", "O Mouse óptico wireless",
                                  "Mouse.png", 100.00M, 10);
            this._keyboard = new Product("Teclado", " O teclado de tamanho normal sem fio",
                                    "Teclado.png", 100.00M, 10);
           this._monitor = new Product("Monitor 25", "Monitor Dell",
                                   "impressora.png", 100.00M, 10);
            this._chair = new Product("Cadeira", "Cadeira gamer",
                                  "Cadeira.png", 100.00M, 10);
        }
        // Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true,this._order.Valid);
        }

        // Ao criar o pedido, o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created,this._order.Status);

        }

        // Ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(this._monitor, 5);
            _order.AddItem(this._mouse, 5);
           
            Assert.AreEqual(2,this._order.Items.Count);

        }

        // Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        [TestCategory("Product")]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
            //  this._order = new Order(this._customer);
            _order.AddItem(this._mouse, 5);
            Assert.AreEqual(5, this._mouse.QuantityOnHand);
        }

        // Ao confirmar pedido, deve gerar um número
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            this._order.Place();

            Assert.AreNotEqual("", this._order.Number);

        }

        // Ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            this._order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, this._order.Status);

        }

        // Dados mais 10 produtos, devem haver duas entregas
        [TestMethod]
        public void ShouldTwoShippingsWhenPurchasedTenProducts()
        {
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.Ship();
            Assert.AreEqual(2, this._order.Deliveries.Count);

        }

        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            this._order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, this._order.Status);

        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.AddItem(this._mouse, 1);
            this._order.Ship();

            this._order.Cancel();
            foreach (var o in this._order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, o.Status);
            }

        }
    }
}
