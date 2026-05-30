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
    }
}
