using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Chinook.EFCoreData.Data;

namespace Chinook.EFCoreData.Repositories;

public class TrackRepository : BaseRepository<Track>, ITrackRepository
{
    protected TrackRepository(ChinookContext context) : base(context)
    {
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}