using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;

namespace Chinook.MinAPI.Api;

public static class PlaylistApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Playlist", async (IChinookSupervisor db) => await db.GetAllPlaylist(1, 30));

        app.MapGet("/Playlist/{id}", async (int id, IChinookSupervisor db) => await db.GetPlaylistById(id));
        
        app.MapPost("/Playlist/", async (PlaylistApiModel playlist, IChinookSupervisor db) => await db.AddPlaylist(playlist));
        
        app.MapPut("/Playlist/", async (PlaylistApiModel playlist, IChinookSupervisor db) => await db.UpdatePlaylist(playlist));
        
        app.MapDelete("/Playlist/{id}", async (int id, IChinookSupervisor db) => await db.DeletePlaylist(id));
    }
}