using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COMP2084MidtermW20.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Election> Election { get; set; }
        public virtual DbSet<Party> Party { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Election>(entity =>
            {
                entity.HasOne(d => d.Party)
                    .WithMany(p => p.Election)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Election_PartyId");
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

        }
    }
}
