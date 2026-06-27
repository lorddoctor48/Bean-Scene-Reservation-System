using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DisplayName("First Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2-50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [DisplayName("Last Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2-50 characters")]
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        [DisplayName("Full Name")]
        public string FullName { get => $"{FirstName} {LastName}"; }
    }
}
