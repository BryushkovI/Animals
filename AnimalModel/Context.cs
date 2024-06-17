using AnimalModel.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalModel
{
    internal class Context : DbContext
    {
        public DbSet<BaseAnimal> Animals => Set<BaseAnimal>();

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseAnimal>().HasKey(a => a.Nameing);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                          Database=Animals;
                                          Trusted_connection=True;");
        }

    }
}
