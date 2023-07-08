using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IEmployeeRepository : IRepository<Employee>, IDisposable
{
    
}