using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using RateMyFood.API.Models;

namespace RateMyFood.API.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Delete(string id);
        T GetById(string id);
        Task<List<T>> Get();
        Task<bool> SaveChangesAsync();

    }
}
