using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.FluentMinAPI.Api;

public static class CustomerApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Customer",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllCustomer(page, pageSize)).WithName("GetCustomers")
            .WithOpenApi();

        app.MapGet("/Customer/{id}", async (int id, IChinookSupervisor db) => await db.GetCustomerById(id)).WithName("GetCustomer")
            .WithOpenApi();

        app.MapPost("/Customer/",
            async ([FromBody] CustomerApiModel customer, IChinookSupervisor db) => await db.AddCustomer(customer)).WithName("AddCustomer")
            .WithOpenApi();

        app.MapPut("/Customer/",
            async ([FromBody] CustomerApiModel customer, IChinookSupervisor db) => await db.UpdateCustomer(customer)).WithName("UpdateCustomer")
            .WithOpenApi();

        app.MapDelete("/Customer/{id}", async (int id, IChinookSupervisor db) => await db.DeleteCustomer(id)).WithName("DeleteCustomer")
            .WithOpenApi();

        app.MapGet("/Customer/SupportRep/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetCustomerBySupportRepId(id, page, pageSize)).WithName("GetCustomersForSupportRep")
            .WithOpenApi();
    }
}