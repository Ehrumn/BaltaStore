﻿using BaltaStore.Domain.Context.Enums;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.Context.Entities;

public class Order : Entity
{
    private readonly IList<OrderItem> _items;
    private readonly IList<Delivery> _deliveries;
    public Order(Customer customer)
    {
        Customer = customer;
        
        CreateDate = DateTime.Now;
        Status = EOrderStatus.Created;
        _items = new List<OrderItem>();
        _deliveries = new List<Delivery>();
    }
    public Customer Customer { get; private set; }
    public string Number { get; private set; }
    public DateTime CreateDate { get; private set; }
    public EOrderStatus Status { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
    public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();


    public void AddItem(Product product, decimal quantity)
    {
        //TODO: validação o ítem
        if (quantity > product.QuantityOnHand)
            AddNotification("OrderItem", $"produto {product.Title} não tem {quantity} em estoque!");

        //Adiciona ao pedido
        var item = new OrderItem(product, quantity);
        _items.Add(item);
    }


    //Criar pedido
    public void Place() 
    {
        //Gera o número do pedido
        Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

        //validar
        if (_items.Count == 0)
            AddNotification("Order", "Este pedido não possui ítens");


    }

    //Pagar um pedido
    public void Pay()
    {
        //A cada 5 produtos é uma entrega

        Status = EOrderStatus.Paid;
        
    }

    //Enviar um pedido
    public void Ship()
    {
        var deliveries = new List<Delivery>();
        //deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));

        var count = 1;
        foreach (var item in _items)
        {
            if(count == 5)
            {
                count = 0;
                deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            }
            count++;
        }

        deliveries.ForEach(x=> x.Ship());
        deliveries.ForEach(x=> _deliveries.Add(x));
    }

    //Cancelar um pedido
    public void Cancel()
    {
        Status = EOrderStatus.Canceled;

        _deliveries.ToList().ForEach(x => x.Cancel());
    }
}
