using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;

namespace Chinook.MinAPI.Api;

public static class InvoiceApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Invoice", async (IChinookSupervisor db) => await db.GetAllInvoice(1, 30));

        app.MapGet("/Invoice/{id}", async (int? id, IChinookSupervisor db) => await db.GetInvoiceById(id));
        
        app.MapPost("/Invoice/", async (InvoiceApiModel invoice, IChinookSupervisor db) => await db.AddInvoice(invoice));
        
        app.MapPut("/Invoice/", async (InvoiceApiModel invoice, IChinookSupervisor db) => await db.UpdateInvoice(invoice));
        
        app.MapDelete("/Invoice/{id}", async (int id, IChinookSupervisor db) => await db.DeleteInvoice(id));
        
        app.MapGet("/Invoice/Customer/{id}", async (int id, IChinookSupervisor db) => await db.GetInvoiceByCustomerId(id, 1, 20));
        
        app.MapGet("/Invoice/Employee/{id}", async (int id, IChinookSupervisor db) => await db.GetInvoiceByEmployeeId(id, 1, 20));
    }
}