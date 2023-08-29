using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.FluentMinAPI.Api;

public static class AlbumApi
{
    public static void RegisterApis(WebApplication app)
    {
        // new Func<int, int, ChinookContext, IAsyncEnumerable<Album>>(async (int page, int pageSize, ChinookContext con) => await con._queryGetAllAlbums)).WithName("GetAlbums")
        //     .WithOpenApi();
        
        //app.MapGet("/Album", async (Func<int, int, Task<PagedList<Album>>> Supervisor) => await Supervisor(1, 30));

        app.MapGet("/Album",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllAlbum(page, pageSize)).WithName("GetAlbums")
            .WithOpenApi();

        app.MapGet("/Album/{id}", async (int? id, IChinookSupervisor db) => await db.GetAlbumById(id)).WithName("GetAlbum")
            .WithOpenApi();

        app.MapPost("/Album/",
            async ([FromBody] AlbumApiModel album, IChinookSupervisor db) => await db.AddAlbum(album)).WithName("AddAlbum")
            .WithOpenApi();

        app.MapPut("/Album/",
            async ([FromBody] AlbumApiModel album, IChinookSupervisor db) => await db.UpdateAlbum(album)).WithName("UpdateAlbum")
            .WithOpenApi();

        app.MapDelete("/Album/{id}", async (int id, IChinookSupervisor db) => await db.DeleteAlbum(id)).WithName("DeleteAlbum")
            .WithOpenApi();

        app.MapGet("/Album/Artist/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetAlbumByArtistId(id, page, pageSize)).WithName("GetAlbumsByArtist")
            .WithOpenApi();
    }
}