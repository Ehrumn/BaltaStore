using BaltaStore.Domain.Context.ValueObjects;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.Context.Entities;

public class Customer : Entity
{
    public Customer(Name name, Document document, Email email, string phone)
    {
        Name = name;
        Document = document;
        Email = email;
        Phone = phone;
        _addresses = new List<Address>();
    }


    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public string Phone { get; private set; }

    private readonly IList<Address> _addresses;
    public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

    #region Methods
    public void AddAddress(Address address)
    {
        //TODO: Validade Address
        //Adicionar Endereço

        _addresses.Add(address);
    }
    #endregion

    public override string ToString()
    {
        return Name.ToString();
    }
}
