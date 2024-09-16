using System.ComponentModel.DataAnnotations;

namespace WorldsCountriesAPI.Models.Dto
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? FlagUrl { get; set; }

    }
}
