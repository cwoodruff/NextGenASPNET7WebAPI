using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Chinook.EFCoreData.Data;

namespace Chinook.EFCoreData.Repositories;

public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
{
    protected InvoiceRepository(ChinookContext context) : base(context)
    {
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}