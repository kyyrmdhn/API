using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Division
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
