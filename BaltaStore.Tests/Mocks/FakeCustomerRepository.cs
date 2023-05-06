using BaltaStore.Domain.Context.Entities;
using BaltaStore.Domain.Context.Repositories;

namespace BaltaStore.Tests.Mocks;

public class FakeCustomerRepository : ICustomerRepository
{
    public bool CheckDocuments(string document)
    {
        return false;
    }

    public bool CheckEmail(string email)
    {
        return false;
    }

    public void Save(Customer customer)
    {
        
    }
}