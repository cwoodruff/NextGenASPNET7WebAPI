using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<bool> EntityExists(int id);
    Task<List<T>> GetAll();
    Task<T?> GetById(int id);
    Task<T> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(int id);
}