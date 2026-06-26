using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    [NotMapped]

    public class HomePageImage
    {
        public string? HomeImagePath { get; set; }
    }
}