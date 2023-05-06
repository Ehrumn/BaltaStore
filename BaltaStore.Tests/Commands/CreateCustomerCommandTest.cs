using BaltaStore.Domain.Context.Commands.CustomerCommands.Inputs;

namespace BaltaStore.Tests.Commands;

[TestClass]
public class CreateCustomerCommandTest
{
    [TestMethod]
    public void ShouldValidateWhenCommandIsValid()
    {
        var command = new CreateCustomerCommand();
        command.FirstName = "Rafael";
        command.LastName = "Dresch";
        command.Document = "04425654960";
        command.Email = "ti-rafael@live.com";
        command.Phone = "41988739009";

        Assert.AreEqual(true, command.Valid());
    }
}