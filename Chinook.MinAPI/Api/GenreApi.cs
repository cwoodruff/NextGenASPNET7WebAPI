using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;

namespace Chinook.MinAPI.Api;

public static class GenreApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Genre", async (IChinookSupervisor db) => await db.GetAllGenre(1, 30));

        app.MapGet("/Genre/{id}", async (int? id, IChinookSupervisor db) => await db.GetGenreById(id));
        
        app.MapPost("/Genre/", async (GenreApiModel genre, IChinookSupervisor db) => await db.AddGenre(genre));
        
        app.MapPut("/Genre/", async (GenreApiModel genre, IChinookSupervisor db) => await db.UpdateGenre(genre));
        
        app.MapDelete("/Genre/{id}", async (int id, IChinookSupervisor db) => await db.DeleteGenre(id));
    }
}