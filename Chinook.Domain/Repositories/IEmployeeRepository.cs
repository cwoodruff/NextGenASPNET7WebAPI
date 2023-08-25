using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IEmployeeRepository : IRepository<Employee>, IDisposable
{
    Task<Employee> GetReportsTo(int? id);
    Task<List<Employee>> GetDirectReports(int? id);
}