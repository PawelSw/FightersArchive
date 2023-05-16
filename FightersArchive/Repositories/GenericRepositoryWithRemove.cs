using FightersArchive.Entities;

namespace FightersArchive.Repositories
{
    public class GenericRepositoryWithRemove<T> : GenericRepository<T> where T : class, IEntity, new() 
    {
        public void Remove(T item) 
        {
            _items.Remove(item);


        }

    }
}
