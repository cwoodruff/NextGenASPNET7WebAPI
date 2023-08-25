using Chinook.Domain.Entities;
using Chinook.Domain.Extensions;

namespace Chinook.Domain.Repositories;

public interface ITrackRepository : IRepository<Track>, IDisposable
{
    Task<PagedList<Track>> GetByAlbumId(int? id, int pageNumber, int pageSize);
    Task<PagedList<Track>> GetByGenreId(int? id, int pageNumber, int pageSize);
    Task<PagedList<Track>> GetByMediaTypeId(int? id, int pageNumber, int pageSize);
    Task<PagedList<Track>> GetByInvoiceId(int? id, int pageNumber, int pageSize);
    Task<PagedList<Track>> GetByPlaylistId(int? id, int pageNumber, int pageSize);
    Task<PagedList<Track>> GetByArtistId(int? id, int pageNumber, int pageSize);
}