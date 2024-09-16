using WorldsCountriesAPI.Models.Dto;

namespace WorldsCountriesAPI.Services.CityService
{
    public interface ICityService
    {
        Task<List<City>> GetAllCities();
        Task<List<City>> GetAllCitiesByCountry(int countryId);
        Task<City?> GetSingleCity(int id);
        Task<List<City>?> AddCity(CityDto city);
        Task<List<City>?> UpdateCity(int id, CityDto request);
        Task<List<City>?> DeleteCity(int id);
    }
}
