using Chinook.EFCoreData.Data;
using Microsoft.EntityFrameworkCore;

namespace Chinook.MinAPI.Api;

public abstract class AlbumsApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/", async (ChinookContext db) => await db.Genres.ToListAsync());
    }
}