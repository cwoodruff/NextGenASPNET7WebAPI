using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;

namespace Chinook.MinAPI.Api;

public static class TrackApi
{
    public static void RegisterApis(WebApplication app)
    {
        //app.MapGet("/Track", async (Func<int, int, Task<PagedList<Track>>> Supervisor) => await Supervisor(1, 30));
        
        app.MapGet("/Track", async (IChinookSupervisor db) => await db.GetAllTrack(1, 30));

        app.MapGet("/Track/{id}", async (int? id, IChinookSupervisor db) => await db.GetTrackById(id));
        
        app.MapPost("/Track/", async (TrackApiModel track, IChinookSupervisor db) => await db.AddTrack(track));
        
        app.MapPut("/Track/", async (TrackApiModel track, IChinookSupervisor db) => await db.UpdateTrack(track));
        
        app.MapDelete("/Track/{id}", async (int id, IChinookSupervisor db) => await db.DeleteTrack(id));
        
        app.MapGet("/Track/Artist/{id}", async (int id, IChinookSupervisor db) => await db.GetTrackByArtistId(id, 1, 20));
        
        app.MapGet("/Track/Album/{id}", async (int id, IChinookSupervisor db) => await db.GetTrackByAlbumId(id, 1, 20));
        
        app.MapGet("/Track/Genre/{id}", async (int id, IChinookSupervisor db) => await db.GetTrackByGenreId(id, 1, 20));
        
        app.MapGet("/Track/Invoice/{id}", async (int id, IChinookSupervisor db) => await db.GetTrackByInvoiceId(id, 1, 20));
        
        app.MapGet("/Track/MediaType/{id}", async (int id, IChinookSupervisor db) => await db.GetTrackByMediaTypeId(id, 1, 20));
    }
}