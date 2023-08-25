using Chinook.Domain.Entities;
using Chinook.Domain.Extensions;

namespace Chinook.Domain.Repositories;

public interface IPlaylistRepository : IRepository<Playlist>, IDisposable
{
    Task<PagedList<Playlist>> GetByTrackId(int? id, int pageNumber, int pageSize);
}