// Copyright (c) WebIT. All Rights Reserved.

using auditproblem.Models;
using Microsoft.EntityFrameworkCore;

namespace auditproblem.Data
{
    public class ApplicationDbContext : Audit.EntityFramework.AuditDbContext // DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Child>(x =>
            {
                x.OwnsOne(c => c.Period);
            });

            builder.Entity<Parent>(x =>
            {
                x.Property(c => c.Name).IsRequired();
                x.HasMany<Child>(c => c.Children);
            });
        }


        public DbSet<Parent> Parents { get; set; }
    }
}
