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
        public int ReservationId { get; set; }

        [StringLength(450)]
        [DisplayName("User")]
        public string? UserId { get; set; }

        [Required]
        public int SittingId { get; set; }

        [MaxLength(50)]
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        [DisplayName("Full name")]
        public string FullName { get => $"{FirstName?.Trim()} {LastName?.Trim()}"; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [DisplayName("Phone Number")]
        [MaxLength(15)]
        public string? PhoneNo { get; set; }
        [DisplayName("Start Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        [Required]
        public TimeOnly ReservationStartTime { get; set; }

        [DisplayName("End Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        [Required]
        public TimeOnly ReservationEndTime { get; set; }

        [Required]
        [DisplayName("People No.")]
        public int NumberOfPeople { get; set; }

        [DisplayName("Source")]
        //[StringLength(20, MinimumLength = 3)]
        [Required]
        public int SourceTitleId { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]

        [ForeignKey(nameof(SourceTitleId))]
        [DisplayName("Source")]
        public ReservationSource? ReservationSource { get; set; }
                                                    

        [DisplayName("Special Requests")]
        public string? SpecialRequests { get; set; }

        public string? Notes { get; set; }

        [DisplayName("Status")]
        [Required]
        public int StatusId { get; set; }   

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Status? Status { get; set; }


        [DeleteBehavior(DeleteBehavior.Restrict)]
        [ForeignKey(nameof(SittingId))]
        public Sitting? Sitting { get; set; }

        //[DeleteBehavior(DeleteBehavior.Restrict)]
        //[DisplayName("Start Time")]
        ////[ForeignKey(nameof(SittingId))]
        //public Sitting? SittingStartTime { get; set; }

        //[DeleteBehavior(DeleteBehavior.Restrict)]
        //[DisplayName("End Time")]
        ////[ForeignKey(nameof(SittingId))]
        //public Sitting? SittingEndTime { get; set; }

        //[DisplayName("Sitting Type")]
        //[DeleteBehavior(DeleteBehavior.Restrict)]
        //public SittingType? SittingType { get; set; }

        [DeleteBehavior(DeleteBehavior.SetNull)]
        public ApplicationUser? User { get; set; }

        public ICollection<Table> Tables { get; set; } = new List<Table>();

    }
}
