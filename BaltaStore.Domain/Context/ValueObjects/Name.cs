namespace BaltaStore.Domain.Context.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Name>()
            .Requires()
            .IsGreaterOrEqualsThan(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
            .IsLowerOrEqualsThan(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
            .IsGreaterOrEqualsThan(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
            .IsLowerOrEqualsThan(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres"));
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }



    public override string ToString() => $"{FirstName} {LastName}";
}
