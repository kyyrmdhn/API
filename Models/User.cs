using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public virtual Employee Employee { get; set; }
        [StringLength(100)]
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
