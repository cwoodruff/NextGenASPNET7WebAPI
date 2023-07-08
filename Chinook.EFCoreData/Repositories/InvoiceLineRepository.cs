using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Chinook.EFCoreData.Data;

namespace Chinook.EFCoreData.Repositories;

public class InvoiceLineRepository : BaseRepository<InvoiceLine>, IInvoiceLineRepository
{
    protected InvoiceLineRepository(ChinookContext context) : base(context)
    {
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}