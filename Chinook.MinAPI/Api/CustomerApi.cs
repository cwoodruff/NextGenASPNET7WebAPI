using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;

namespace Chinook.MinAPI.Api;

public static class CustomerApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Customer", async (IChinookSupervisor db) => await db.GetAllCustomer(1, 30));

        app.MapGet("/Customer/{id}", async (int id, IChinookSupervisor db) => await db.GetCustomerById(id));
        
        app.MapPost("/Customer/", async (CustomerApiModel customer, IChinookSupervisor db) => await db.AddCustomer(customer));
        
        app.MapPut("/Customer/", async (CustomerApiModel customer, IChinookSupervisor db) => await db.UpdateCustomer(customer));
        
        app.MapDelete("/Customer/{id}", async (int id, IChinookSupervisor db) => await db.DeleteCustomer(id));
        
        app.MapGet("/Customer/SupportRep/{id}", async (int id, IChinookSupervisor db) => await db.GetCustomerBySupportRepId(id, 1, 20));
    }
}