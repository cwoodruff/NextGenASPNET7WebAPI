using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Chinook.EFCoreData.Data;

namespace Chinook.EFCoreData.Repositories;

public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
{
    protected AlbumRepository(ChinookContext context) : base(context)
    {
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}