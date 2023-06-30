using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Models
{
    public partial class PostCompanyEntities : DbContext
    {
        public PostCompanyEntities()
            : base("name=PostCompanyEntitiesDB")
        {
        }

        public virtual DbSet<Costumer> Costumer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Costumer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Costumer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Costumer>()
                .Property(e => e.SSN)
                .IsUnicode(false);

            modelBuilder.Entity<Costumer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Costumer>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Costumer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PersonalID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CostumerSSN)
                .IsUnicode(false);
        }
    }
}
