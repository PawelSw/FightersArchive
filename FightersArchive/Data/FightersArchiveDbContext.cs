using FightersArchive.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FightersArchive.Data
{
    public class FightersArchiveDbContext : DbContext
    {
        public DbSet<Fighter> Fighters => Set<Fighter>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("FightersArchiveDb");
        }
    }
}
