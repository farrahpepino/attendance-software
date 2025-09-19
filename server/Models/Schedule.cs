using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    [Table("Schedules")]
    public class Schedule
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        public int UserCode { get; set; }

        // Monday
        [Column(TypeName = "varchar(20)")]
        public string? Mon_Shift1 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Mon_Shift2 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Mon_Shift3 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Mon_Break { get; set; }

        // Tuesday
        [Column(TypeName = "varchar(20)")]
        public string? Tue_Shift1 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Tue_Shift2 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Tue_Shift3 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Tue_Break { get; set; }

        // Wednesday
        [Column(TypeName = "varchar(20)")]
        public string? Wed_Shift1 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Wed_Shift2 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Wed_Shift3 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Wed_Break { get; set; }

        // Thursday
        [Column(TypeName = "varchar(20)")]
        public string? Thu_Shift1 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Thu_Shift2 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Thu_Shift3 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Thu_Break { get; set; }

        // Friday
        [Column(TypeName = "varchar(20)")]
        public string? Fri_Shift1 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Fri_Shift2 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Fri_Shift3 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Fri_Break { get; set; }

        // Saturday
        [Column(TypeName = "varchar(20)")]
        public string? Sat_Shift1 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Sat_Shift2 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Sat_Shift3 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Sat_Break { get; set; }

        // Sunday
        [Column(TypeName = "varchar(20)")]
        public string? Sun_Shift1 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Sun_Shift2 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Sun_Shift3 { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Sun_Break { get; set; }
    }
}
