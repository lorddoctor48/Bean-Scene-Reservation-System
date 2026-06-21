using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    public class Reservation
    {
        [Key]
        [Required]
        public required int ReservationID { get; set; }

        public string? MemberID { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Sitting? Sitting { get; set; }

        [Required]
        public required int SittingId { get; set; }   // <-- FIXED

        [MaxLength(50)]
        [DisplayName("First Name")]
        [Required]
        public required string FirstName { get; set; }

        [MaxLength(50)]
        [DisplayName("Last Name")]
        [Required]
        public required string LastName { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [DisplayName("Phone Number")]
        [MaxLength(15)]
        public string? PhoneNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM YYYY}")]
        [DisplayName("Reservation Date")]
        [Required]
        public required DateOnly ReservationDate { get; set; }

        [DisplayName("Reservation Start Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        [Required]
        public required TimeOnly ReservationStartTime { get; set; }

        //[DisplayName("Duration (Min)")]
        //[Required]
        //public required int DurationMin { get; set; }

        ////public TimeOnly ReservationEndTime
        ////{


        ////    get {return ReservationStartTime - DurationMin}
        ////}

        ////public  TimeOnly ReservationEndTime =>  ReservationStartTime - DurationMin;

        [DisplayName("Reservation End Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        [Required]
        public required TimeOnly ReservationEndTime { get; set; }

        //[DisplayName]
        //[ForeignKey(nameof(Table))]
        //public string? TableNo { get; set; }

        //[DeleteBehavior(DeleteBehavior.Restrict)]
        //public Table? Table { get; set; }

        [Required]
        public required int NumberOfPeople { get; set; }

        [DisplayName("Source")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public required int SourceTitleId { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]

        [ForeignKey(nameof(SourceTitleId))]
        public ReservationSource? ReservationSource { get; set; }
                                                    

        [DisplayName("Special Requests")]
        public string? SpecialRequests { get; set; }

        public string? Notes { get; set; }

        [DisplayName("Status")]
        [Required]
        public required int StatusId { get; set; }   

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Status? Status { get; set; }

        public ICollection<Table> Table { get; set; } = [];

    }
}
