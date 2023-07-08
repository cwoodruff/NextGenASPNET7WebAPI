using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Chinook.EFCoreData.Data;

namespace Chinook.EFCoreData.Repositories;

public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
{
    protected ArtistRepository(ChinookContext context) : base(context)
    {
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}