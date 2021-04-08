using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using Ticketing.Data.Enums;
using Ticketing.Data.Models;

namespace Ticketing.Persistence
{
    public class TicketingDbContext : DbContext
    {

        public TicketingDbContext(DbContextOptions<TicketingDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StaffMember> Staff { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<StorageFile> StorageFiles { get; set; }
        public DbSet<Reply> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.MobileNumber).IsRequired().HasMaxLength(14);
                entity.HasIndex(c => c.Email).IsUnique();
                entity.Property(c => c.Status).HasDefaultValue(UserStatus.Active).IsRequired();
                entity.Property(c => c.Password).IsRequired();

                entity.HasMany(c => c.Tickets)
                .WithOne(c => c.Client);

                entity.HasMany(e => e.Replies)
                .WithOne(e => e.Client);

            });

            modelBuilder.Entity<StaffMember>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.MobileNumber).IsRequired().HasMaxLength(14);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.BirthDate).HasColumnType("date").IsRequired();
                entity.Property(e => e.Status).HasDefaultValue(UserStatus.Active).IsRequired();

                entity.HasMany(e => e.Tickets)
                .WithOne(e => e.Employee);

                entity.HasMany(e => e.Replies)
                .WithOne(e => e.Employee);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id);
                entity.Property(p => p.Name).IsRequired();
                entity.HasIndex(p => p.Name).IsUnique();

                entity.HasMany(p => p.Tickets)
                .WithOne(p => p.Product);
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Id);
                entity.Property(r => r.ReplyStatus).HasDefaultValue(ReplyStatus.New);
                entity.Property(r => r.CreateDateTime).IsRequired();

                entity.HasMany(r => r.StorageFiles)
                .WithOne(r => r.Reply);

                entity.HasOne(r => r.Employee)
                .WithMany(r => r.Replies);

                entity.HasOne(r => r.Client)
               .WithMany(r => r.Replies);

                entity.HasOne(r => r.Ticket)
                .WithMany(r => r.Replies);
            });

            modelBuilder.Entity<StorageFile>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id);

                entity.HasOne(s => s.Reply)
                .WithMany(s => s.StorageFiles);

                entity.HasOne(s => s.Ticket)
                .WithMany(s => s.StorageFiles);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(t => t.CreateDateTime).IsRequired();
                entity.Property(t => t.CloseDate).IsRequired(false);
          

                entity.HasMany(t => t.Replies)
                .WithOne(t => t.Ticket);

                entity.HasOne(t => t.Client)
                .WithMany(t => t.Tickets);
            });
        }
    }
}
