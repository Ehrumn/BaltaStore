using BaltaStore.Domain.Context.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.Context.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.Context.Entities;
using BaltaStore.Domain.Context.Repositories;
using BaltaStore.Domain.Context.Services;
using BaltaStore.Domain.Context.ValueObjects;
using BaltaStore.Shared.Commands;

namespace BaltaStore.Domain.Context.Handlers;

public class CustomerHandler : Notifiable<Notification>, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IEmailService _emailService;
    public CustomerHandler(ICustomerRepository customerRepository, IEmailService emailService)
    {
        _customerRepository = customerRepository;
        _emailService = emailService;
    }

    public ICommandResult Handle(CreateCustomerCommand command)
    {
        //verificar se o CPF já existe na base
        if (_customerRepository.CheckDocuments(command.Document))
            AddNotification("Document", "Este CPF já está em uso!");

        //verificar se o email já existe na base
        if (_customerRepository.CheckEmail(command.Email))
            AddNotification("Email", "Este E-mail já está em uso!");

        //Criar os VOs
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document);
        var email = new Email(command.Email);

        //Criar a entidade
        var customer = new Customer(name, document, email,command.Phone);

        //validar Entidades e VOs
        AddNotifications(name.Notifications);
        AddNotifications(document.Notifications);
        AddNotifications(email.Notifications);
        AddNotifications(customer.Notifications);

        if (!IsValid)
            return null;

        //Persistir o cliente
        _customerRepository.Save(customer);

        //enviar um email de boas vindas.
        _emailService.Send(email.Address, "hello@test.com", "Bem Vindo", "Seja bem vindo ao BaltaStore");

        //retornar o resultado para a tela

        return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
    }

    public ICommandResult Handle(AddAddressCommand command)
    {
        throw new NotImplementedException();
    }
}