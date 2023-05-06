using BaltaStore.Domain.Context.Entities;
using BaltaStore.Domain.Context.Enums;
using BaltaStore.Domain.Context.ValueObjects;

namespace BaltaStore.Tests.Entities;

[TestClass]
public class OrderTests
{
    private Customer _customer;
    private Order _order;
    private Product _mouse;
    private Product _keyboard;
    private Product _chair;
    private Product _monitor;

    public OrderTests()
    {
        var name = new Name("Rafael", "Caetano");
        var document = new Document("04425654960");
        var email = new Email("ti-rafael@live.com");
        _customer = new Customer(name, document, email, "5512345678");
        _order = new Order(_customer);
        _mouse = new Product("Mouse Gamer", "Mouse Gamer", "Mouse.jpg", 100M, 10);
        _keyboard = new Product("Teclado Gamer", "Teclado Gamer", "Teclado.jpg", 100M, 10);
        _chair = new Product("Cadeira Gamer", "Cadeira Gamer", "Cadeira.jpg", 100M, 10);
        _monitor = new Product("Monitor Gamer", "Monitor Gamer", "Monitor.jpg", 100M, 10);
    }

    //Consigo criar um novo pedido
    [TestMethod]
    public void ShouldCreateOrderWhenValid()
    {
        Assert.AreEqual(true, _order.IsValid);
    }

    //Ao criar o pedido, o status deve ser created
    [TestMethod]
    public void StatusShouldBeCreatedWhenOrderCreated()
    {
        Assert.AreEqual(EOrderStatus.Created, _order.Status);
    }

    //Ao adicionar um novo item, a quantidade de itens deve mudar
    [TestMethod]
    public void ShouldReturnTwoWhenAddedTwoValidItems()
    {
        _order.AddItem(_monitor, 5);
        _order.AddItem(_mouse, 5);
        Assert.AreEqual(2, _order.Items.Count);
    }

    //ao adicionar um ovo item, deve substituir a quantidade do produto
    [TestMethod]
    public void ShouldReturnFiveWhenAddedPurchasedFiveitem()
    {
        _order.AddItem(_mouse, 5);
        Assert.AreEqual(_mouse.QuantityOnHand, 5);
    }

    //ao confirmar pedido, deve gerar um numero
    [TestMethod]
    public void ShouldReturnANumberWhenOrderPlaced()
    {
        _order.Place();
        Assert.AreNotEqual("", _order.Number);
    }

    //Ao pagar um pedido, o status de ser PAGO
    [TestMethod]
    public void ShouldReturnPAIDWhenOrderPaid()
    {
        _order.Pay();
        Assert.AreEqual(EOrderStatus.Paid, _order.Status);
    }

    //Dados 10 produtos, devem haver 2 entregas
    [TestMethod]
    public void ShouldReturnTwoWhenPurchasedTenProducts()
    {
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);

        _order.Ship();

        Assert.AreEqual(2, _order.Deliveries.Count);
    }

    //ao cancelar o pedido, o status deve ser cancelado
    [TestMethod]
    public void StatusShouldReturnCanceledWhenOrderIsCanceled()
    {
        _order.Cancel();
        Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
    }

    //ao cancelar o pedido, deve cancelar as entregas
    [TestMethod]
    public void ShouldCancleShippingWhenOrderIsCanceled()
    {
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);
        _order.AddItem(_mouse, 1);

        _order.Ship();
        _order.Cancel();

        foreach (var x in _order.Deliveries)
        {
            Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
        }
    }

    public void CreateCustomer()
    {
        //Verificar se CPF já existe

        //Verifica se o Email já existe

        //Criar os VOs

        //Criar a entidade

        //Validar as entidades e VOs

        //Inserir o cliente no banco

        //Envia o convite do Slack

        //Envia um email de Boas Vindas
    }
}
