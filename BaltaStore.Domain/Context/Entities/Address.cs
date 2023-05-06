using BaltaStore.Domain.Context.Enums;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.Context.Entities;

public class Address : Entity
{
    public Address(string street, string number, string complements, string district, string city, string state, string country, string zipCode, EAddressType type)
    {
        Street = street;
        Number = number;
        Complements = complements;
        District = district;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        Type = type;
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Complements { get; private set; }
    public string District { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
    public EAddressType Type { get; private set; }

    public override string ToString() => $"{Street}, {Number} = {City}/{State}";
}
