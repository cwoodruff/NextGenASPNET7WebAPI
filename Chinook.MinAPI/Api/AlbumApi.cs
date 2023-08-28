using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;

namespace Chinook.MinAPI.Api;

public static class AlbumApi
{
    public static void RegisterApis(WebApplication app)
    {
        //app.MapGet("/Album", async (Func<int, int, Task<PagedList<Album>>> Supervisor) => await Supervisor(1, 30));
        
        app.MapGet("/Album", async (IChinookSupervisor db) => await db.GetAllAlbum(1, 30));

        app.MapGet("/Album/{id}", async (int? id, IChinookSupervisor db) => await db.GetAlbumById(id));
        
        app.MapPost("/Album/", async (AlbumApiModel album, IChinookSupervisor db) => await db.AddAlbum(album));
        
        app.MapPut("/Album/", async (AlbumApiModel album, IChinookSupervisor db) => await db.UpdateAlbum(album));
        
        app.MapDelete("/Album/{id}", async (int id, IChinookSupervisor db) => await db.DeleteAlbum(id));
        
        app.MapGet("/Album/Artist/{id}", async (int id, IChinookSupervisor db) => await db.GetAlbumByArtistId(id, 1, 20));
    }
}