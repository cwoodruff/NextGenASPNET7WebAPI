using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Chinook.EFCoreData.Data;
using Microsoft.EntityFrameworkCore;

namespace Chinook.EFCoreData.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ChinookContext context) : base(context)
    {
    }

    public async Task<Employee> GetReportsTo(int? id) =>
        (await _context.Employees.FindAsync(id))!;

    public async Task<List<Employee>> GetDirectReports(int? id) =>
        await _context.Employees.Where(e => e.ReportsTo == id).AsNoTrackingWithIdentityResolution().ToListAsync();

    public async Task<Employee> GetToReports(int? id) =>
        (await _context.Employees
            .FindAsync(_context.Employees.Where(e => e.Id == id)
                .Select(p => new { p.ReportsTo })
                .First()))!;
}