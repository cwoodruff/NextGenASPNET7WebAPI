using Chinook.Domain.Supervisor;

namespace Chinook.MinAPI.Api;

public static class AlbumsApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/", async (IChinookSupervisor db) => await db.GetAllAlbum(1, 30));
        
        //app.MapGet("/", async (Func<int, int, Task<PagedList<Album>>> Supervisor) => await Supervisor(1, 30));
    }
}