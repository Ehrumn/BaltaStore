using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.Context.Entities;

public class OrderItem : Entity
{
    public OrderItem(Product product, decimal quantity)
    {
        Product = product;
        Quantity = quantity;
        Price = product.Price;

        if (product.QuantityOnHand < quantity)
            AddNotification("Quantity", "Out of hand");

        product.DecreaseQuantity(quantity);
    }

    public Product Product { get; private set; }
    public Decimal Quantity { get; private set; }
    public Decimal Price { get; private set; }

}
