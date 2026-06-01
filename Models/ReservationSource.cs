using System.ComponentModel.DataAnnotations;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    public class ReservationSource
    {
        [Key]
        [MaxLength(20)]
        public required string sourceTitle { get; set; }

    }
}
