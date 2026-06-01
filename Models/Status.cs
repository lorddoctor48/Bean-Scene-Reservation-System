using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    public class Status
    {
        [Key]
        [DisplayName("Status")]

        [MaxLength(50)]
        public required string StatusTitle { get; set; }
    }
}
