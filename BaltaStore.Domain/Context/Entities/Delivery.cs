using BaltaStore.Domain.Context.Enums;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.Context.Entities;

public class Delivery : Entity
{
    public Delivery(DateTime estimatedDeliveryDate)
    {
        CreateDate = DateTime.Now;
        EstimatedDeliveryDate = estimatedDeliveryDate;
        Status = EDeliveryStatus.Waiting;
    }

    public DateTime CreateDate { get; private set; }
    public DateTime EstimatedDeliveryDate { get; private set; }
    public EDeliveryStatus Status { get; private set; }

    public void Ship()
    {
        //Se a data estimada de entrega for no passado, não entregar

        Status = EDeliveryStatus.Shipped;
    }

    public void Cancel()
    {
        if (Status != EDeliveryStatus.Delivered)
            Status = EDeliveryStatus.Canceled;
    }
}
