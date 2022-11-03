using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }
        //ICollection paling bawah menunjukkan relasi many to 1
        //banyak division boleh dimiliki oleh 1 department
        [ForeignKey("DivisionId")]
        //json ignore agar tidak perlu insert division di dalam post department
        [JsonIgnore]
        //tanda tanya menandakan boleh null
        public Division? Division { get; set; }
    }
}
