namespace BaltaStore.Domain.Context.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;

        AddNotifications(new Contract<Email>()
            .Requires()
            .IsEmail(address, "Email", "Email inválido"));
    }

    public string Address { get; private set; }

    public override string ToString() => Address;
}
