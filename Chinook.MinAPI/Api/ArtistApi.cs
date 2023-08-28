using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;

namespace Chinook.MinAPI.Api;

public static class ArtistApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Artist", async (IChinookSupervisor db) => await db.GetAllAlbum(1, 30));

        app.MapGet("/Artist/{id}", async (int id, IChinookSupervisor db) => await db.GetArtistById(id));
        
        app.MapPost("/Artist/", async (ArtistApiModel artist, IChinookSupervisor db) => await db.AddArtist(artist));
        
        app.MapPut("/Artist/", async (ArtistApiModel artist, IChinookSupervisor db) => await db.UpdateArtist(artist));
        
        app.MapDelete("/Artist/{id}", async (int id, IChinookSupervisor db) => await db.DeleteArtist(id));
    }
}