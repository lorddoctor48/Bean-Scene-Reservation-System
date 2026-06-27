using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Assessment_Bean_Scene_Registration_Application.Models;

namespace Project_Assessment_Bean_Scene_Registration_Application.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
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

            modelBuilder.Entity<SittingType>().HasData(
                new SittingType { SittingTypeId = 1, SittingTitle = "Breakfast" },
                new SittingType { SittingTypeId = 2, SittingTitle = "Lunch" },
                new SittingType { SittingTypeId = 3, SittingTitle = "Dinner" }

            );

            modelBuilder.Entity<ReservationSource>().HasData(
                new ReservationSource { SourceTitleId = 1, SourceTitle = "Phone" },
                new ReservationSource { SourceTitleId = 2, SourceTitle = "Email" },
                new ReservationSource { SourceTitleId = 3, SourceTitle = "Online" },
                new ReservationSource { SourceTitleId = 4, SourceTitle = "In-person" }

            );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusTitle = "Pending" },
                new Status { StatusId = 2, StatusTitle = "Confirmed" },
                new Status { StatusId = 3, StatusTitle = "Cancelled" },
                new Status { StatusId = 4, StatusTitle = "Seated" },
                new Status { StatusId = 5, StatusTitle = "Completed" }
            );

            modelBuilder.Entity<TableArea>().HasData(
                new TableArea { TableAreaId = 1, Area = "Main" },
                new TableArea { TableAreaId = 2, Area = "Outside" },
                new TableArea { TableAreaId = 3, Area = "Balcony" }
                );

            modelBuilder.Entity<Table>().HasData(
                new Table { TableNo = "M1", TableAreaId = 1 },
                new Table { TableNo = "M2", TableAreaId = 1 },
                new Table { TableNo = "M3", TableAreaId = 1 },
                new Table { TableNo = "M4", TableAreaId = 1 },
                new Table { TableNo = "M5", TableAreaId = 1 },
                new Table { TableNo = "M6", TableAreaId = 1 },
                new Table { TableNo = "M7", TableAreaId = 1 },
                new Table { TableNo = "M8", TableAreaId = 1 },
                new Table { TableNo = "M9", TableAreaId = 1 },
                new Table { TableNo = "M10", TableAreaId = 1 },

                new Table { TableNo = "O1", TableAreaId = 2 },
                new Table { TableNo = "O2", TableAreaId = 2 },
                new Table { TableNo = "O3", TableAreaId = 2 },
                new Table { TableNo = "O4", TableAreaId = 2 },
                new Table { TableNo = "O5", TableAreaId = 2 },
                new Table { TableNo = "O6", TableAreaId = 2 },
                new Table { TableNo = "O7", TableAreaId = 2 },
                new Table { TableNo = "O8", TableAreaId = 2 },
                new Table { TableNo = "O9", TableAreaId = 2 },
                new Table { TableNo = "O10", TableAreaId = 2 },

                new Table { TableNo = "B1",  TableAreaId = 3 },
                new Table { TableNo = "B2",  TableAreaId = 3 },
                new Table { TableNo = "B3",  TableAreaId = 3 },
                new Table { TableNo = "B4",  TableAreaId = 3 },
                new Table { TableNo = "B5",  TableAreaId = 3 },
                new Table { TableNo = "B6",  TableAreaId = 3 },
                new Table { TableNo = "B7",  TableAreaId = 3 },
                new Table { TableNo = "B8",  TableAreaId = 3 },
                new Table { TableNo = "B9",  TableAreaId = 3 },
                new Table { TableNo = "B10",  TableAreaId = 3 }
            );

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
                        .HasPrincipalKey(r => r.ReservationId)
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