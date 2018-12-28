
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteStore.Domain.StoreContext.ValueObjects;

namespace TesteStore.Tests.ValueObjects
{
    [TestClass]
    public class PhoneTests
    {
        private CellPhone validPhone;

        private CellPhone invalidDPhone;

        public PhoneTests()
        {
            this.validPhone = new CellPhone("(83) 98747-7358");
            this.invalidDPhone = new CellPhone("83 8747-7358");

        }

        [TestMethod]
        [TestCategory("Phone")]
        public void ShouldReturnNotificationWhenPhoneIsNotValid()
        {
            Assert.AreEqual(false, invalidDPhone.Valid);
            Assert.AreEqual(1, invalidDPhone.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Phone")]
        public void ShouldReturnNotificationWhenPhoneIsValid()
        {
            Assert.AreEqual(true, validPhone.Valid);
            Assert.AreEqual(0, validPhone.Notifications.Count);
        }
    }
}