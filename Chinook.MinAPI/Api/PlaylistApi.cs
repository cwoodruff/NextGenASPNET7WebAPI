using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Api;

public static class PlaylistApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Playlist",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllPlaylist(page, pageSize)).WithName("GetPlaylists")
            .WithOpenApi();

        app.MapGet("/Playlist/{id}", async (int id, IChinookSupervisor db) => await db.GetPlaylistById(id)).WithName("GetPlaylist")
            .WithOpenApi();

        app.MapPost("/Playlist/",
            async ([FromBody] PlaylistApiModel playlist, IChinookSupervisor db) => await db.AddPlaylist(playlist)).WithName("AddPlaylist")
            .WithOpenApi();

        app.MapPut("/Playlist/",
            async ([FromBody] PlaylistApiModel playlist, IChinookSupervisor db) => await db.UpdatePlaylist(playlist)).WithName("UpdatePlaylist")
            .WithOpenApi();

        app.MapDelete("/Playlist/{id}", async (int id, IChinookSupervisor db) => await db.DeletePlaylist(id)).WithName("DeletePlaylist")
            .WithOpenApi();
    }
}