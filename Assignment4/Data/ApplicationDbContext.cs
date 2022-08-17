using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment4.Models;

namespace Assignment4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment4.Models.Brand> Brand { get; set; } = default!;

        public DbSet<Assignment4.Models.Product>? Product { get; set; }
    }
}
