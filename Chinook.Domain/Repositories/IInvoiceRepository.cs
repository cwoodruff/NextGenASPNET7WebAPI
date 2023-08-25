using Chinook.Domain.Entities;
using Chinook.Domain.Extensions;

namespace Chinook.Domain.Repositories;

public interface IInvoiceRepository : IRepository<Invoice>, IDisposable
{
    Task<PagedList<Invoice>> GetByCustomerId(int? id, int pageNumber, int pageSize);
    Task<PagedList<Invoice>> GetByEmployeeId(int? id, int pageNumber, int pageSize);
}