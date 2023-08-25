using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Chinook.EFCoreData.Data;

namespace Chinook.EFCoreData.Repositories;

public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
{
    public ArtistRepository(ChinookContext context) : base(context)
    {
    }
}