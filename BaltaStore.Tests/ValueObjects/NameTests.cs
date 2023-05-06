using BaltaStore.Domain.Context.ValueObjects;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        private Name validName;
        private Name invalidName;

        public NameTests()
        {
            validName = new Name("Rafael", "Dresch");
            invalidName = new Name("", "Dresch");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsInvalid()
        {
            Assert.AreEqual(true, invalidName.Notifications.Any());
        }

        [TestMethod]
        public void ShouldNotReturnNotificationWhenNameIsValid()
        {
            Assert.AreEqual(false, validName.Notifications.Any());
        }
    }
}
