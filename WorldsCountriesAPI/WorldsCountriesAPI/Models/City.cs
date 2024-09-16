using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WorldsCountriesAPI.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        //Navigation Properties

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [JsonIgnore]
        public Country? Country { get; set; }
    }
}
