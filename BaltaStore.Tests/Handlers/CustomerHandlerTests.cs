using BaltaStore.Domain.Context.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.Context.Handlers;
using BaltaStore.Tests.Mocks;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Rafael";
            command.LastName = "Dresch";
            command.Document = "21227381387";
            command.Email = "test@test.com";
            command.Phone = "41998763210";


            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());

            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);

            Assert.AreEqual(true, handler.IsValid);
        }
    }
}