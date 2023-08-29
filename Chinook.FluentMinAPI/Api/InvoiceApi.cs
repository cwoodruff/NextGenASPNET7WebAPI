using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.FluentMinAPI.Api;

public static class InvoiceApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Invoice",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllInvoice(page, pageSize)).WithName("GetInvoices")
            .WithOpenApi();

        app.MapGet("/Invoice/{id}", async (int? id, IChinookSupervisor db) => await db.GetInvoiceById(id)).WithName("GetInvoice")
            .WithOpenApi();

        app.MapPost("/Invoice/",
            async ([FromBody] InvoiceApiModel invoice, IChinookSupervisor db) => await db.AddInvoice(invoice)).WithName("AddInvoice")
            .WithOpenApi();

        app.MapPut("/Invoice/",
            async ([FromBody] InvoiceApiModel invoice, IChinookSupervisor db) => await db.UpdateInvoice(invoice)).WithName("UpdateInvoice")
            .WithOpenApi();

        app.MapDelete("/Invoice/{id}", async (int id, IChinookSupervisor db) => await db.DeleteInvoice(id)).WithName("DeleteInvoice")
            .WithOpenApi();

        app.MapGet("/Invoice/Customer/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetInvoiceByCustomerId(id, page, pageSize)).WithName("GetInvoicesForCustomer")
            .WithOpenApi();

        app.MapGet("/Invoice/Employee/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetInvoiceByEmployeeId(id, page, pageSize)).WithName("GetInvoicesForEmployee")
            .WithOpenApi();
    }
}