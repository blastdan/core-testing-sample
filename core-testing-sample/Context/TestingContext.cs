using CoreTestingSample.Context.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTestingSample.Context
{
    public class TestingContext : DbContext
    {
        public TestingContext(DbContextOptions<TestingContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies{ get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var personBuilder = modelBuilder.Entity<Person>();
            personBuilder.ToTable("person");
            personBuilder.HasKey(p => p.Id);
            personBuilder.HasOne(p => p.Address)
                         .WithOne(a => a.Person)
                         .HasForeignKey<Address>(a => a.PersonId);
                         
            personBuilder.HasOne(p => p.Company)
                         .WithOne(c => c.Person)
                         .HasForeignKey<Company>(a => a.PersonId); ;
                
            modelBuilder.Entity<Company>()
                        .ToTable("company")
                        .HasKey(c => c.Id);

            modelBuilder.Entity<Address>()
                        .ToTable("address")
                        .HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
