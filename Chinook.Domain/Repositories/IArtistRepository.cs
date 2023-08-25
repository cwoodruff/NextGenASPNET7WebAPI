using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IArtistRepository : IRepository<Artist>, IDisposable
{
}