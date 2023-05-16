using FightersArchive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersArchive.Repositories
{
    public class ListRepository<T> : IRepository<T> where T: class, IEntity, new()      
    {
        protected readonly List<T> _items = new();

        public IEnumerable<T> GetAll()
        { 
            return _items.ToList(); 
        }
        public void Add(T item)
        {
             item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Save()
        {

        }

        public T GetById(int id)
        {
            return _items.Single(x => x.Id == id);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

    }
}

