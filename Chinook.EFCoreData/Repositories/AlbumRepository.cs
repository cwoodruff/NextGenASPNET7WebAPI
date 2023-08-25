using Chinook.Domain.Entities;
using Chinook.Domain.Extensions;
using Chinook.Domain.Repositories;
using Chinook.EFCoreData.Data;
using Microsoft.EntityFrameworkCore;

namespace Chinook.EFCoreData.Repositories;

public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
{
    public AlbumRepository(ChinookContext context) : base(context)
    {
    }

    public async Task<PagedList<Album>> GetByArtistId(int? id, int pageNumber, int pageSize) =>
        await PagedList<Album>.ToPagedListAsync(_context.Albums.Where(a => a.ArtistId == id)
                .AsNoTrackingWithIdentityResolution(),
            pageNumber,
            pageSize);
}