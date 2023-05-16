using FightersArchive.Entities;
using Microsoft.EntityFrameworkCore;

namespace FightersArchive.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;


        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();

        }

        public IEnumerable<T> GetAll() 
        {
            return _dbSet.ToList();

        }
        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Display()
        {
            foreach (var item in _dbSet) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
