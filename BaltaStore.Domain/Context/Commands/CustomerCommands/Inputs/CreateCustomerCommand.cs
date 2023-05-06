using BaltaStore.Shared.Commands;

namespace BaltaStore.Domain.Context.Commands.CustomerCommands.Inputs;

public class CreateCustomerCommand : Notifiable<Notification>, ICommand
{
    //FailFastValidation
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public bool Valid()
    {
        AddNotifications(new Contract<CreateCustomerCommand>()
            .Requires()
            .IsGreaterOrEqualsThan(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
            .IsLowerOrEqualsThan(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
            .IsGreaterOrEqualsThan(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
            .IsLowerOrEqualsThan(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres")
            .IsEmail(Email, "Email", "O E-mail é inválido")
            .IsGreaterOrEqualsThan(Document, 11, "Document", "CPF inválido"));

        return IsValid;
    }

    //Se o usuário existe no banco (email)
    //Se o usuário existe no banco (CPF)
}