using Microsoft.EntityFrameworkCore;
using SPHF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Data// Step 2
{
    public class TankDbContext:DbContext
    {
        public TankDbContext(DbContextOptions<TankDbContext>options):base(options)
        {
                
        }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
