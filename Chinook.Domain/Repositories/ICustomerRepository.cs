using Chinook.Domain.Entities;
using Chinook.Domain.Extensions;

namespace Chinook.Domain.Repositories;

public interface ICustomerRepository : IRepository<Customer>, IDisposable
{
    Task<PagedList<Customer>> GetBySupportRepId(int? id, int pageNumber, int pageSize);
}