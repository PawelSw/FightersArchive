using FightersArchive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersArchive.Repositories
{
    public class GenericRepository<T> where T: class, IEntity, new()
       
    {
        protected readonly List<T> _items = new();

        public void Add(T item)
        {
             item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }

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

