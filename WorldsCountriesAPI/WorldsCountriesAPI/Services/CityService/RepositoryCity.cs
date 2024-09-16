using WorldsCountriesAPI.Services.Generic;

namespace WorldsCountriesAPI.Services.CityService
{
    public class RepositoryCity : Repository<City>, IRepositoryCity
    {
        private readonly DataContext _context;
        public RepositoryCity(DataContext context) 
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<City> GetByCountryId(int countryId)
        {
            return _context.Cities.Where(e=>e.CountryId== countryId);
        }
    }
}
