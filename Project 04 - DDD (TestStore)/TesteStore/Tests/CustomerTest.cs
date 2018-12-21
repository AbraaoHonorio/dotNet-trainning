using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TesteStore.Domain.StoreContext.Entities;
using TesteStore.Domain.StoreContext.ValueObjects;

namespace Tests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        [TestCategory("Customer")]
        public void TestandoCriacaoCustomer()
        {
            var name = new Name("Abrao", "allysson");
            var document = new Document("123456789");
            var email = new Email("contado@abraao.com.br");
            var phone = new Phone("5583988887777");
            var customer = new Customer(name, document, email, phone);
            var mouse = new Product("Mouse", "O Mouse óptico wireless",
                                    "Mouse.png", 59.90M, 20);
            var teclado = new Product("Teclado", " O teclado de tamanho normal sem fio",
                                    "Teclado.png", 100.00M, 1);
            var impressora = new Product("Impressora", "O Mouse óptico wireless",
                                   "impressora.png", 300.00M, 27);

            var order = new Order(customer);
          /*  order.AddItem(new OrderItem(mouse, 20));
            order.AddItem(new OrderItem(teclado, 1));
            order.AddItem(new OrderItem(impressora, 20));*/

            //relizando pedido
            order.Place();


            // verficiando se meu pedido é válido
            var valid = order.Valid;
            // efetuando um pagamento
            order.Pay();

            // enviando a entrega
            order.Ship();

            // efetuando um cancelamento
            order.Cancel();
        }
    }
}
