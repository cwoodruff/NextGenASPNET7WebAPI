using Chinook.Domain.ApiModels;
using Chinook.Domain.Repositories;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.FluentMinAPI.Api;

public static class AlbumApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Album",
            new Func<int, int, IAlbumRepository, object>((int page, int pageSize, IAlbumRepository repository) => repository.GetAll(page, pageSize))).WithName("GetAlbums")
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