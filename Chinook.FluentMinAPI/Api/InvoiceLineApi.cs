using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.FluentMinAPI.Api;

public static class InvoiceLineApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/InvoiceLine",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllInvoiceLine(page, pageSize)).WithName("GetInvoiceLines")
            .WithOpenApi();

        app.MapGet("/InvoiceLine/{id}", async (int id, IChinookSupervisor db) => await db.GetInvoiceLineById(id)).WithName("GetInvoiceLine")
            .WithOpenApi();

        app.MapPost("/InvoiceLine/",
            async ([FromBody] InvoiceLineApiModel invoiceLine, IChinookSupervisor db) =>
            await db.AddInvoiceLine(invoiceLine)).WithName("AddInvoiceLine")
            .WithOpenApi();

        app.MapPut("/InvoiceLine/",
            async ([FromBody] InvoiceLineApiModel invoiceLine, IChinookSupervisor db) =>
            await db.UpdateInvoiceLine(invoiceLine)).WithName("UpdateInvoiceLine")
            .WithOpenApi();

        app.MapDelete("/InvoiceLine/{id}", async (int id, IChinookSupervisor db) => await db.DeleteInvoiceLine(id)).WithName("DeleteInvoiceLine")
            .WithOpenApi();

        app.MapGet("/InvoiceLine/Invoice/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetInvoiceLineByInvoiceId(id, page, pageSize)).WithName("GetInvoiceLineForInvoice")
            .WithOpenApi();

        app.MapGet("/InvoiceLine/Track/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetInvoiceLineByTrackId(id, page, pageSize)).WithName("GetInvoiceLineForTrack")
            .WithOpenApi();
    }
}