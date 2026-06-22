using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    [Index(nameof(SourceTitle), IsUnique = true)]

    public class ReservationSource
    {

        [Key]
        public int SourceTitleId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public required string SourceTitle { get; set; }

    }
}
