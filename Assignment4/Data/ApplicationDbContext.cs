using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projects.Models;

namespace Assignment4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<projects.Models.Brand> Brand { get; set; } = default!;

        public DbSet<projects.Models.Product>? Product { get; set; }
    }
}
