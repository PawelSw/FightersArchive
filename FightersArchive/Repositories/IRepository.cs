using FightersArchive.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersArchive.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        T GetById(int id);
        void Remove(T item);
        void Save();

    }
}
