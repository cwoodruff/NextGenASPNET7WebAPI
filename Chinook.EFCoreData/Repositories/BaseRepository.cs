using System.Linq.Expressions;
using Chinook.Domain.Entities;
using Chinook.Domain.Extensions;
using Chinook.Domain.Repositories;
using Chinook.EFCoreData.Data;
using Microsoft.EntityFrameworkCore;

namespace Chinook.EFCoreData.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected ChinookContext _context;

    protected BaseRepository(ChinookContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<bool> EntityExists(int? id) =>
        await _context.Set<T>().AnyAsync(a => a.Id == id);

    public async Task<PagedList<T>> GetAll(int pageNumber, int pageSize) =>
        await PagedList<T>.ToPagedListAsync(_context.Set<T>().AsNoTrackingWithIdentityResolution(),
            pageNumber,
            pageSize);

    public async Task<T?> GetById(int? id) => await _context.Set<T>().SingleAsync(e => e.Id == id);

    public async Task<T> Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Update(T entity)
    {
        if (!await EntityExists(entity.Id))
            return false;
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        if (!await EntityExists(id))
            return false;
        var toRemove = await _context.Set<T>().FindAsync(id);
        if (toRemove != null) _context.Set<T>().Remove(toRemove);
        await _context.SaveChangesAsync();
        return true;
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>()
            .Where(expression)
            .AsNoTrackingWithIdentityResolution();
    }
}