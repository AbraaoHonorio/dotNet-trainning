using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TesteStore.Domain.StoreContext.Entities;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Customer")]
        public void TestandoCriacaoCustomer()
        {
            var customer = new Customer(
                "Abraao",
                "1233456789",
                "contato@abraao.com.br",
                "5583911112222",
                new List<string>()
                );

        }
    }
}
