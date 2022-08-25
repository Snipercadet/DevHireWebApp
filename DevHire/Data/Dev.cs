using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevHire.Data
{
    [Table("Devs")]
    public class Dev
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Skill { get; set; }
        [Required]
        public double Fee { get; set; }
        public bool IsFavourite { get; set; }
        public bool IsHired { get; set; }
    }
}
