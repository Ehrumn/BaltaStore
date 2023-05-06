using BaltaStore.Domain.Context.ValueObjects;

namespace BaltaStore.Tests;

[TestClass]
public class DocumentTests
{
    private Document validDocument;
    private Document invalidDocument;
    public DocumentTests()
    {
        validDocument = new Document("04425654960");
        invalidDocument = new Document("12345678910");
    }

    [TestMethod]
    public void ShouldReturnNotificationWhenDocumentIsNotValid()
    {
        Assert.AreEqual(false, invalidDocument.IsValid);
        Assert.AreEqual(true, invalidDocument.Notifications.Any());
    }

    [TestMethod]
    public void ShouldNOTReturnNotificationWhenDocumentIsValid()
    {
        Assert.AreEqual(true, validDocument.IsValid);
        Assert.AreEqual(false, validDocument.Notifications.Any());
    }
}