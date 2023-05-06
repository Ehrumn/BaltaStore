using BaltaStore.Domain.Context.Commands.CustomerCommands.Inputs;
using BaltaStore.Shared.Commands;

namespace BaltaStore.Domain.Context.Commands.OrderCommands.Inputs;

public class PlaceOrderCommand : Notifiable<Notification>, ICommand
{
    public Guid CustomerId { get; set; }

    public IList<OrderItemCommand> OrderItems { get; set; }

    public PlaceOrderCommand()
    {
        OrderItems = new List<OrderItemCommand>();
    }

    public bool Valid()
    {
        AddNotifications(new Contract<PlaceOrderCommand>()
           .IsLowerOrEqualsThan(CustomerId.ToString().Length, 36, "CustomerId", "Identificador do Cliente inválido")
           .IsLowerOrEqualsThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido encontrado"));

        return IsValid;
    }
}

public class OrderItemCommand : Notifiable<Notification>, ICommand
{
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }

    public bool Valid()
    {
        throw new NotImplementedException();
    }
}