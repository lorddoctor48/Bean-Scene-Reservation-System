using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_Assessment_Bean_Scene_Registration_Application.Models
{
    public class Reservation
    {
        [Key]
        public required int ReservationID { get; set; }

        public string? MemberID { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Sitting? Sitting { get; set; }

        public required int SittingId { get; set; }   // <-- FIXED

        [MaxLength(50)]
        [DisplayName("First Name")]
        public required string FirstName { get; set; }

        [MaxLength(50)]
        [DisplayName("Last Name")]
        public required string LastName { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [DisplayName("Phone Number")]
        [MaxLength(15)]
        public string? PhoneNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Reservation Date")]
        public required DateOnly ReservationDate { get; set; }

        [DisplayName("Reservation Start Time")]
        [DataType(DataType.Time)]
        public required TimeOnly ReservationStartTime { get; set; }

        [DisplayName("Duration (Min)")]
        public required int DurationMin { get; set; }

        //public TimeOnly ReservationEndTime
        //{


        //    get {return ReservationStartTime - DurationMin}
        //}

        //public  TimeOnly ReservationEndTime =>  ReservationStartTime - DurationMin;

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Table? Table { get; set; }

        public string? tableNo { get; set; }

        public required int NumberOfPeople { get; set; }

        public ReservationSource? ReservationSource { get; set; }

        [DisplayName("Special Requests")]
        public string? SpecialRequests { get; set; }

        public string? Notes { get; set; }

        [DisplayName("Status")]
        public required string StatusTitle { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Status? Status { get; set; }
    }
}
