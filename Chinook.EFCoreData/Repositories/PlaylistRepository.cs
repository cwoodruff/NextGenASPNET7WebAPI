using Chinook.Domain.Entities;
using Chinook.Domain.Extensions;
using Chinook.Domain.Repositories;
using Chinook.EFCoreData.Data;
using Microsoft.EntityFrameworkCore;

namespace Chinook.EFCoreData.Repositories;

public class PlaylistRepository : BaseRepository<Playlist>, IPlaylistRepository
{
    public PlaylistRepository(ChinookContext context) : base(context)
    {
    }

    public async Task<PagedList<Playlist>> GetByTrackId(int? id, int pageNumber, int pageSize) =>
        await PagedList<Playlist>.ToPagedListAsync(_context.Playlists.Where(c => c.Tracks!.Any(o => o.Id == id))
                .AsNoTrackingWithIdentityResolution(),
            pageNumber,
            pageSize);
}