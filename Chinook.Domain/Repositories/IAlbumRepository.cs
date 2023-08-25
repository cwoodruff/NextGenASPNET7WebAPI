using Chinook.Domain.Entities;
using Chinook.Domain.Extensions;

namespace Chinook.Domain.Repositories;

public interface IAlbumRepository : IRepository<Album>, IDisposable
{
    Task<PagedList<Album>> GetByArtistId(int? id, int pageNumber, int pageSize);
}