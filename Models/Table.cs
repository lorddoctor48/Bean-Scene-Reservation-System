using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    public class Table
    {
        [Key]
        [DisplayName("Table Number")]
        [Required]
        public required string TableNo { get; set; }

        [DisplayName("Table Area")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [ForeignKey(nameof(Area))]
        public required string TableArea { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public TableArea? Area { get; set; }

        [DisplayName("Assigned Reservations")]
        public ICollection<Reservation> Reservations { get; } = [];
    }
}
