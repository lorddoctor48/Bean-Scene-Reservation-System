using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    public class Table
    {
        [Key]
        [DisplayName("Table Number")]
        public required string TableNo { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public TableArea? Area { get; set; }
    }
}
