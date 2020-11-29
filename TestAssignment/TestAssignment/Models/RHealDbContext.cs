using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestAssignment.Models
{
    public class RHealDbContext : DbContext
    {
        public RHealDbContext() : base("name=RHealDbConnection")
        {
        }

        // define DbSet<T> for Categories and Products
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }

        public DbSet<Trainer> Trainer { get; set; }

        public DbSet<StudentCourse> StudentCourse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}