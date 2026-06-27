using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    [Index(nameof(SittingTitle), IsUnique = true)]

    public class SittingType
    {
        [Key]
        public int SittingTypeId { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [DisplayName("Sitting")]
        [Required]
        public required string SittingTitle { get; set; }
    }
}
