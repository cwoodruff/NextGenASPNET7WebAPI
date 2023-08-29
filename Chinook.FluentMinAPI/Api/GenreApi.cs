using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.FluentMinAPI.Api;

public static class GenreApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Genre",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllGenre(page, pageSize)).WithName("GetGenres")
            .WithOpenApi();

        app.MapGet("/Genre/{id}", async (int? id, IChinookSupervisor db) => await db.GetGenreById(id)).WithName("GetGenre")
            .WithOpenApi();

        app.MapPost("/Genre/",
            async ([FromBody] GenreApiModel genre, IChinookSupervisor db) => await db.AddGenre(genre)).WithName("AddGenre")
            .WithOpenApi();

        app.MapPut("/Genre/",
            async ([FromBody] GenreApiModel genre, IChinookSupervisor db) => await db.UpdateGenre(genre)).WithName("UpdateGenre")
            .WithOpenApi();

        app.MapDelete("/Genre/{id}", async (int id, IChinookSupervisor db) => await db.DeleteGenre(id)).WithName("DeleteGenre")
            .WithOpenApi();
    }
}