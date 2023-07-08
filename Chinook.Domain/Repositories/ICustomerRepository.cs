using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface ICustomerRepository : IRepository<Customer>, IDisposable
{
    
}