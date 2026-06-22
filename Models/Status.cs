using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    public class Status
    {
        [Key]
        [Required]
        public int StatusId { get; set; }

        [DisplayName("Status")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public required string StatusTitle { get; set; }
    }
}
