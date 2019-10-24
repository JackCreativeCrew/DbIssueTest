using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbIssueTest
{
    public class TdbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "User ID=postgres;Password=postgres;Server=localhost;Port=5432;"
              + "Database=testIssue;Integrated Security=true;Pooling=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Toy> Toys { get; set; }
    }

    public class Parent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string Name { get; set; }
        
        public DateTime Dob { get; set; }
        
        public List<Child> Children { get; set; } = new List<Child>();
    }

    public class Child
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string Name { get; set; }
        
        public DateTime Dob { get; set; }
        
        public List<Toy> ChildsToys { get; set; } = new List<Toy>();

        public virtual Parent Parent1 { get; set; }
    }

    public class Toy
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string Name { get; set; }
        
        public string desc { get; set; }
        
        public virtual Child OwningChild { get; set; }
    }
}
