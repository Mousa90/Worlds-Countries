using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorldsCountriesAPI.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [StringLength(5000)]
        public string? Description { get; set; }

        [StringLength(2048)]
        public string? ImageUrl { get; set; }

        [StringLength(2048)]
        public string? FlagUrl { get; set; }

        //Navigation Properties
        public List<City>? Cities { get; set; }
    }
}
