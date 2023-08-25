using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Chinook.EFCoreData.Data;

namespace Chinook.EFCoreData.Repositories;

public class MediaTypeRepository : BaseRepository<MediaType>, IMediaTypeRepository
{
    public MediaTypeRepository(ChinookContext context) : base(context)
    {
    }
}