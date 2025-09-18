using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  server.Models{
    
    [Table("Users")]
    public class User{
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public int UserCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(5)]
        public string Role { get; set; } = "user";

        [Required]
        [MaxLength(7)]
        public string Status { get; set; } = "absent";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

