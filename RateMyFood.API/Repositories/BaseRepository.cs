using Microsoft.EntityFrameworkCore;
using RateMyFood.API.DbContexts;
using RateMyFood.API.Models;

namespace RateMyFood.API.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T :  BaseEntity
    {
        private readonly RateMyFoodContext _context;
        private readonly DbSet<T> table;

        public BaseRepository(RateMyFoodContext rateMyFoodContext)
        {
            _context = rateMyFoodContext;
            table = _context.Set<T>();
        }

        public void Add(T entity)
        {
            table.Add(entity);
        }

        public void Delete(string id)
        {
            T existing = table.Where( c => c.Id.ToString() == id).FirstOrDefault();
            table.Remove(existing);
        }

        public Task<List<T>> Get()
        {
            return table.ToListAsync();
        }

        public T GetById(string id)
        {
            return table.Where(c => c.Id.ToString() == id).FirstOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
