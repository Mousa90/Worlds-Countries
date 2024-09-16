using Azure.Core;
using Microsoft.EntityFrameworkCore;
using WorldsCountriesAPI.Models.Dto;
using WorldsCountriesAPI.Services.CityService;

namespace WorldsCountriesAPI.Services.CityService
{
    public class CityService : ICityService
    {
        private readonly DataContext _context;

        public CityService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<City>> GetAllCities()
        {
            var cities = await _context.Cities.ToListAsync();
            return cities;
        }
        public async Task<List<City>> GetAllCitiesByCountry(int countryId)
        {
            var cities = await _context.Cities.Where(c => c.CountryId == countryId).ToListAsync();
            return cities;
        }

        public async Task<City?> GetSingleCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city is null)
                return null;

            return city;
        }
        public async Task<List<City>?> AddCity(CityDto request)
        {
            var country = await _context.Countries.FindAsync(request.CountryId);
            if (country == null)
                return null;

            var newCity = new City
            {
                Name = request.Name,
                CountryId = request.CountryId
            };

            _context.Cities.Add(newCity);
            await _context.SaveChangesAsync();
            return await _context.Cities.ToListAsync();
        }

        public async Task<List<City>?> UpdateCity(int id, CityDto request)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city is null)
                return null;

            var newCity = new City
            {
                Name = request.Name,
                CountryId = request.CountryId
            };

            city.Name = newCity.Name;
            city.CountryId = newCity.CountryId;

            await _context.SaveChangesAsync();

            return await _context.Cities.ToListAsync();
        }

        public async Task<List<City>?> DeleteCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city is null)
                return null;

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return await _context.Cities.ToListAsync();
        }
    }
}
