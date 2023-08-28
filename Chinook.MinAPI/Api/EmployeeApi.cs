using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;

namespace Chinook.MinAPI.Api;

public static class EmployeeApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Employee", async (IChinookSupervisor db) => await db.GetAllEmployee(1, 30));

        app.MapGet("/Employee/{id}", async (int? id, IChinookSupervisor db) => await db.GetEmployeeById(id));
        
        app.MapPost("/Employee/", async (EmployeeApiModel employee, IChinookSupervisor db) => await db.AddEmployee(employee));
        
        app.MapPut("/Employee/", async (EmployeeApiModel employee, IChinookSupervisor db) => await db.UpdateEmployee(employee));
        
        app.MapDelete("/Employee/{id}", async (int id, IChinookSupervisor db) => await db.DeleteEmployee(id));
        
        app.MapGet("/Employee/directreports/{id}", async (int id, IChinookSupervisor db) => await db.GetEmployeeDirectReports(id));
        
        app.MapGet("/Employee/reportsto/{id}", async (int id, IChinookSupervisor db) => await db.GetEmployeeReportsTo(id));
    }
}