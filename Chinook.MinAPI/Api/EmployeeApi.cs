using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Api;

public static class EmployeeApi
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/Employee",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllEmployee(page, pageSize)).WithName("GetEmployees")
            .WithOpenApi();

        app.MapGet("/Employee/{id}", async (int? id, IChinookSupervisor db) => await db.GetEmployeeById(id)).WithName("GetEmployee")
            .WithOpenApi();

        app.MapPost("/Employee/",
            async ([FromBody] EmployeeApiModel employee, IChinookSupervisor db) => await db.AddEmployee(employee)).WithName("AddEmployee")
            .WithOpenApi();

        app.MapPut("/Employee/",
            async ([FromBody] EmployeeApiModel employee, IChinookSupervisor db) => await db.UpdateEmployee(employee)).WithName("UpdateEmployee")
            .WithOpenApi();

        app.MapDelete("/Employee/{id}", async (int id, IChinookSupervisor db) => await db.DeleteEmployee(id)).WithName("DeleteEmployee")
            .WithOpenApi();

        app.MapGet("/Employee/directreports/{id}",
            async (int id, IChinookSupervisor db) => await db.GetEmployeeDirectReports(id)).WithName("GetEmployeeDirectReports")
            .WithOpenApi();

        app.MapGet("/Employee/reportsto/{id}",
            async (int id, IChinookSupervisor db) => await db.GetEmployeeReportsTo(id)).WithName("GetEmployeeDirectReport")
            .WithOpenApi();
    }
}