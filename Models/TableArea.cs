using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    public class TableArea
    {
        [Key]
        [MaxLength(20)]
        public required string Area {  get; set; }
    }
}
