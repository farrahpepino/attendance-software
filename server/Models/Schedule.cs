using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models{
    
    [Table("Schedules")]
    public class Schedule{
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string Day { get; set; } = string.Empty;

        public string? Shift1 { get; set; }
        public string? Shift2 { get; set; }
        public string? Shift3 { get; set; }
        public string? Break { get; set; }
    }
}
