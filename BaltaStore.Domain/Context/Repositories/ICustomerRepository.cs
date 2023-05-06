using BaltaStore.Domain.Context.Entities;

namespace BaltaStore.Domain.Context.Repositories;

public interface ICustomerRepository
{
    bool CheckDocuments(string document);
    bool CheckEmail(string email);

    void Save(Customer customer);
}