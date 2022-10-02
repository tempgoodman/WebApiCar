using System;
using Microsoft.EntityFrameworkCore;
using Inchcape.Repository.Models;

namespace Inchcape.Repository
{
    public class InchcapeContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "InchcapeDb");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<FinancialType>  FinancialTypes{ get; set; }
        public DbSet<Plan> Plans { get; set; }
    }
}

