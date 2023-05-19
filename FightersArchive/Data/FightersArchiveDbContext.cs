using FightersArchive.Data.Entities;
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
        public FightersArchiveDbContext(DbContextOptions<FightersArchiveDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Fighter> Fighters { get; set; }


    }
}
