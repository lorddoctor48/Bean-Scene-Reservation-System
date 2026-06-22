using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Assessment_Bean_Scene_Registration_Application.Models;

namespace Project_Assessment_Bean_Scene_Registration_Application.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<SittingType> SittingTypes { get; set; }

        public DbSet<Sitting> Sittings { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<ReservationSource> ReservationsSource { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Table> Table { get; set; }

        public DbSet<TableArea> TableAreas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             This make ensure EF does automatically fallback to its naming convention
             The associative entity of ReservationTable will the keys of ReservationID and TableNo
            */
            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Tables)
                .WithMany(t => t.Reservations)
                .UsingEntity<Dictionary<string, object>>(
                    "ReservationTable",
                    j => j
                        .HasOne<Table>()
                        .WithMany()
                        .HasForeignKey("TableNo")
                        .HasPrincipalKey(t => t.TableNo)
                        .OnDelete(DeleteBehavior.Cascade),

                    j => j
                        .HasOne<Reservation>()
                        .WithMany()
                        .HasForeignKey("ReservationID")
                        .HasPrincipalKey(r => r.ReservationID)
                        .OnDelete(DeleteBehavior.Cascade),

                    j =>
                    {
                        j.HasKey("ReservationID", "TableNo");
                        j.ToTable("ReservationTable");
                    }
                );

            base.OnModelCreating(modelBuilder);
        }


    }
}