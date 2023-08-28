using Chinook.Domain.Entities;
using Chinook.Domain.Extensions;
using Chinook.Domain.Supervisor;
using Chinook.EFCoreData.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Chinook.MinAPI.Api;

public static class AlbumsApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/", async (IChinookSupervisor db) => await db.GetAllAlbum(1, 30));
        
        app.MapGet("/", async (Func<int, int, Task<PagedList<Album>>> Supervisor) => await Supervisor(1, 30));
    }
}