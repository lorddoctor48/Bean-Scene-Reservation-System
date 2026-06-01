using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    public class Sitting
    {
        [Key]
        public int SittingId { get; set; }
       
        [DisplayName("Sitting Title")]
        [MaxLength(20)]
        public required int SittingTypeID { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public SittingType? SittingType { get; set; }

        [Required]
        [DisplayName("Sitting Start Date")]
        public DateOnly SittingStartDate { get; set; }

        [Required]
        [DisplayName("Sitting End Date")]
        public DateOnly SittingEndDate { get; set; }

        [Required]
        [DisplayName("Sitting Start Time")]
        public TimeOnly SittingStartTime { get; set; }

        [Required]
        [DisplayName("Sitting End Time")]
        public TimeOnly SittingEndTime { get; set; }

        [Required]
        [DisplayName("Capacity")]
        public int SittingCapacity { get; set; }

        [DisplayName("Sitting Closed?")]
        public required bool IsClosed { get; set; }

        [DisplayName("Closure Date?")]
        public DateOnly? ClosureDate { get; set; }

        [MaxLength(20)]
        [DisplayName("Closure Reason?")]
        public string? ClosureReason { get; set; }

    }
}
