using Chinook.Domain.Entities;
using Chinook.Domain.Extensions;
using Chinook.Domain.Repositories;
using Chinook.EFCoreData.Data;
using Microsoft.EntityFrameworkCore;

namespace Chinook.EFCoreData.Repositories;

public class TrackRepository : BaseRepository<Track>, ITrackRepository
{
    public TrackRepository(ChinookContext context) : base(context)
    {
    }

    public async Task<PagedList<Track>> GetByAlbumId(int? id, int pageNumber, int pageSize) =>
        await PagedList<Track>.ToPagedListAsync(_context.Tracks.Where(a => a.AlbumId == id)
                .AsNoTrackingWithIdentityResolution(),
            pageNumber,
            pageSize);

    public async Task<PagedList<Track>> GetByGenreId(int? id, int pageNumber, int pageSize) =>
        await PagedList<Track>.ToPagedListAsync(_context.Tracks.Where(a => a.GenreId == id)
                .AsNoTrackingWithIdentityResolution(),
            pageNumber,
            pageSize);

    public async Task<PagedList<Track>> GetByMediaTypeId(int? id, int pageNumber, int pageSize) =>
        await PagedList<Track>.ToPagedListAsync(_context.Tracks.Where(a => a.MediaTypeId == id)
                .AsNoTrackingWithIdentityResolution(),
            pageNumber,
            pageSize);

    public async Task<PagedList<Track>> GetByPlaylistId(int? id, int pageNumber, int pageSize) =>
        await PagedList<Track>.ToPagedListAsync(_context.Playlists.Where(p => p.Id == id).SelectMany(p => p.Tracks!)
                .AsNoTrackingWithIdentityResolution(),
            pageNumber,
            pageSize);

    public async Task<PagedList<Track>> GetByArtistId(int? id, int pageNumber, int pageSize) =>
        await PagedList<Track>.ToPagedListAsync(_context.Albums.Where(a => a.ArtistId == id).SelectMany(t => t.Tracks!)
                .AsNoTrackingWithIdentityResolution(),
            pageNumber,
            pageSize);

    public async Task<PagedList<Track>> GetByInvoiceId(int? id, int pageNumber, int pageSize) =>
        await PagedList<Track>.ToPagedListAsync(_context.Tracks.Where(c => c.InvoiceLines!.Any(o => o.InvoiceId == id))
                .AsNoTrackingWithIdentityResolution(),
            pageNumber,
            pageSize);
}