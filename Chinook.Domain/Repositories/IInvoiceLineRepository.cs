using Chinook.Domain.Entities;
using Chinook.Domain.Extensions;

namespace Chinook.Domain.Repositories;

public interface IInvoiceLineRepository : IRepository<InvoiceLine>, IDisposable
{
    Task<PagedList<InvoiceLine>> GetByInvoiceId(int? id, int pageNumber, int pageSize);
    Task<PagedList<InvoiceLine>> GetByTrackId(int? id, int pageNumber, int pageSize);
}