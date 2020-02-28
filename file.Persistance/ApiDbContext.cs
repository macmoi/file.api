using System;
using Microsoft.EntityFrameworkCore;
using file.Core.Models;

namespace file.Persistance
{
    public class ApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Builder for user table
            builder.Entity<User>().ToTable("user");
            builder.Entity<User>().HasKey(p => p.id);
            builder.Entity<User>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.name).IsRequired().HasMaxLength(40);
            builder.Entity<User>().Property(p => p.lastname).IsRequired().HasMaxLength(40);
            builder.Entity<User>().HasMany(p => p.attachments).WithOne(p => p.user).HasForeignKey(p => p.userId);

            // Builder config for attachment table
            builder.Entity<Attachment>().ToTable("attachment");
            builder.Entity<Attachment>().HasKey(p => p.id);
            builder.Entity<Attachment>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Attachment>().Property(p => p.fileName).HasMaxLength(40);
            builder.Entity<Attachment>().Property(p => p.file).IsRequired();
        }
    }
}