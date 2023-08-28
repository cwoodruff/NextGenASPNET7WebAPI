using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;

namespace Chinook.MinAPI.Api;

public static class InvoiceLineApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/InvoiceLine", async (IChinookSupervisor db) => await db.GetAllInvoiceLine(1, 30));

        app.MapGet("/InvoiceLine/{id}", async (int id, IChinookSupervisor db) => await db.GetInvoiceLineById(id));
        
        app.MapPost("/InvoiceLine/", async (InvoiceLineApiModel invoiceLine, IChinookSupervisor db) => await db.AddInvoiceLine(invoiceLine));
        
        app.MapPut("/InvoiceLine/", async (InvoiceLineApiModel invoiceLine, IChinookSupervisor db) => await db.UpdateInvoiceLine(invoiceLine));
        
        app.MapDelete("/InvoiceLine/{id}", async (int id, IChinookSupervisor db) => await db.DeleteInvoiceLine(id));
        
        app.MapGet("/InvoiceLine/Invoice/{id}", async (int id, IChinookSupervisor db) => await db.GetInvoiceLineByInvoiceId(id, 1, 20));
        
        app.MapGet("/InvoiceLine/Track/{id}", async (int id, IChinookSupervisor db) => await db.GetInvoiceLineByTrackId(id, 1, 20));
    }
}