using WorldsCountriesAPI.Models.Dto;

namespace WorldsCountriesAPI.Services.CountryService
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountries();
        Task<Country?> GetSingleCountry(int id);
        Task<List<Country>> AddCountry(CountryDto country);
        Task<List<Country>?> UpdateCountry(int id, CountryDto request);
        Task<List<Country>?> DeleteCountry(int id);
    }
}
