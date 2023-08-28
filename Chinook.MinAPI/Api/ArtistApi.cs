using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Api;

public static class ArtistApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Artist",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllAlbum(page, pageSize)).WithName("GetArtists")
            .WithOpenApi();

        app.MapGet("/Artist/{id}", async (int id, IChinookSupervisor db) => await db.GetArtistById(id)).WithName("GetArtist")
            .WithOpenApi();

        app.MapPost("/Artist/",
            async ([FromBody] ArtistApiModel artist, IChinookSupervisor db) => await db.AddArtist(artist)).WithName("AddArtist")
            .WithOpenApi();

        app.MapPut("/Artist/",
            async ([FromBody] ArtistApiModel artist, IChinookSupervisor db) => await db.UpdateArtist(artist)).WithName("UpdateArtist")
            .WithOpenApi();

        app.MapDelete("/Artist/{id}", async (int id, IChinookSupervisor db) => await db.DeleteArtist(id)).WithName("DeleteArtist")
            .WithOpenApi();
    }
}