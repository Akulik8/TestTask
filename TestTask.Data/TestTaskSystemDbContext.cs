using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Models;

namespace TestTask.Data
{
    public class TestTaskSystemDbContext : DbContext
    {
        public TestTaskSystemDbContext(DbContextOptions<TestTaskSystemDbContext> options) : base(options)
        { }

        public DbSet<Car> Cars => Set<Car>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
