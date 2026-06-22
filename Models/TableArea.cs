using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    public class TableArea
    {
        [Key]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public required string Area {  get; set; }
    }
}
