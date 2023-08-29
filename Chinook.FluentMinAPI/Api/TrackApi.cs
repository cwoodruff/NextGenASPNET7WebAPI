using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.FluentMinAPI.Api;

public static class TrackApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Track",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllTrack(page, pageSize)).WithName("GetTracks")
            .WithOpenApi();

        app.MapGet("/Track/{id}", async (int? id, IChinookSupervisor db) => await db.GetTrackById(id)).WithName("GetTrack")
            .WithOpenApi();

        app.MapPost("/Track/",
            async ([FromBody] TrackApiModel track, IChinookSupervisor db) => await db.AddTrack(track)).WithName("AddTrack")
            .WithOpenApi();

        app.MapPut("/Track/",
            async ([FromBody] TrackApiModel track, IChinookSupervisor db) => await db.UpdateTrack(track)).WithName("UpdateTrack")
            .WithOpenApi();

        app.MapDelete("/Track/{id}", async (int id, IChinookSupervisor db) => await db.DeleteTrack(id)).WithName("DeleteTrack")
            .WithOpenApi();

        app.MapGet("/Track/Artist/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetTrackByArtistId(id, page, pageSize)).WithName("GetTracksForArtist")
            .WithOpenApi();

        app.MapGet("/Track/Album/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetTrackByAlbumId(id, page, pageSize)).WithName("GetTracksForAlbum")
            .WithOpenApi();

        app.MapGet("/Track/Genre/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetTrackByGenreId(id, page, pageSize)).WithName("GetTracksForGenre")
            .WithOpenApi();

        app.MapGet("/Track/Invoice/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetTrackByInvoiceId(id, page, pageSize)).WithName("GetTracksForInvoice")
            .WithOpenApi();

        app.MapGet("/Track/MediaType/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetTrackByMediaTypeId(id, page, pageSize)).WithName("GetTracksForMediaType")
            .WithOpenApi();
    }
}