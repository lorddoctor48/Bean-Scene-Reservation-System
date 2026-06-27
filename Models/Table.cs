using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    [Index(nameof(TableNo), IsUnique = true)]
    public class Table
    {
        [Key]
        [DisplayName("Table Number")]
        [Required]
        public required string TableNo { get; set; }

        [DisplayName("Table Area")]
        [Required]
        public int TableAreaId { get; set; } 

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public TableArea? TableArea { get; set; } 

        [DisplayName("Assigned Reservations")]
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
