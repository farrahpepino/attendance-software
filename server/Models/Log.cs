using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models{
    
    [Table("Logs")]
    public class Log{
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [MaxLength(7)]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
