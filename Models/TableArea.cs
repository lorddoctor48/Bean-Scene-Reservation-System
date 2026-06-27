using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    [Index(nameof(Area), IsUnique = true)]

    public class TableArea
    {
        [Key]
        public int TableAreaId { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public required string Area {  get; set; }

        [NotMapped]
        public bool HasChildren { get; set; }

        public ICollection<Table>? Tables { get; set; }
    }
}
