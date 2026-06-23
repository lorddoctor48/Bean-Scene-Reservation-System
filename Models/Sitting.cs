using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    public class Sitting
    {
        [Key]
        [Required]
        [DisplayName("Sitting Number")]
        public int SittingId { get; set; }

        [DisplayName("Sitting Title")]
        [Required]
        public required int SittingTypeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        [DisplayName("Sitting Date")]
        public required DateOnly SittingDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        [DataType(DataType.Date)]
        [DisplayName("Sitting Start Date")]
        public DateOnly SittingStartDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        [DataType(DataType.Date)]
        [DisplayName("Sitting End Date")]
        public DateOnly SittingEndDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        [DisplayName("Sitting Start Time")]
        public TimeOnly SittingStartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
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



        [DeleteBehavior(DeleteBehavior.Restrict)]
        [DisplayName("Sitting Type")]
        public SittingType? SittingType { get; set; }

        //[DeleteBehavior(DeleteBehavior.Restrict)]
        //[DisplayName("Start Time")]
        //public Sitting? StartTime { get; set; }


        //[DeleteBehavior(DeleteBehavior.Restrict)]
        //[DisplayName("End Time")]
        //public Sitting? EndTime { get; set; }

        //public Sitting()
        //{
        //    Date = DateOnly.FromDateTime(DateTime.Today);
        //    SittingTypeId = 1;                     // Morning (hard-coded ID)
        //    SittingTypeId = 0;                     // int default to 0, equivalent of "null"
        //    StartTime = new TimeOnly(9, 00);    // 9am
        //    EndTime = new TimeOnly(12, 00);     // 12pm
        //    IsClosed = true;
        //}
    }
}
