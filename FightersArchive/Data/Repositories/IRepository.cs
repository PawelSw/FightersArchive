using FightersArchive.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersArchive.Data.Repositories
{
    public interface IRepository<T> : IWriteRepository<T>, IReadRepository<T> where T : class, IEntity
    {
    }
}
