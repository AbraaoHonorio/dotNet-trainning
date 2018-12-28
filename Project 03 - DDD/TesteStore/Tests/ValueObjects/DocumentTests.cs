using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TesteStore.Domain.StoreContext.Entities;
using TesteStore.Domain.StoreContext.ValueObjects;

namespace TesteStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {

        private Document validDocument;

        private Document invalidDocument;

        public DocumentTests()
        {
            this.validDocument = new Document("10468306005");
            this.invalidDocument = new Document("12345678910");
        }
        [TestMethod]
        [TestCategory("Document")]
        public void ShouldReturnNotificationWhenDucmentIsNotValid()
        {
            Assert.AreEqual(false, invalidDocument.Valid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);

        }

        [TestMethod]
        [TestCategory("Document")]
        public void ShouldReturnNotificationWhenDucmentIsValid()
        {

            Assert.AreEqual(true, validDocument.Valid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
