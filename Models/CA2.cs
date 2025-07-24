using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
    public class CA2
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }
        public string? Genre { get; set; }

    }
}
