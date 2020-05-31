using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Concrete
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<MainTable> MainTable { get; set; }
        public DbSet<ListOfCalculations> ListOfCalculations { get; set; }
        public DbSet<Users> Users { get; set; }
    }
    
}
