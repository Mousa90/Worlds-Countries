using WorldsCountriesAPI.Services.Generic;

namespace WorldsCountriesAPI.Services.CityService
{
    public interface IRepositoryCity:IRepository<City>
    {
        IEnumerable<City> GetByCountryId(int countryId);
    }
}
