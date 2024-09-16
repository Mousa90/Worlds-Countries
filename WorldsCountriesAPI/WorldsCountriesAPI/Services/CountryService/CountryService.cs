using WorldsCountriesAPI.Models.Dto;

namespace WorldsCountriesAPI.Services.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly DataContext _context;

        public CountryService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllCountries()
        {
            var countries = await _context.Countries
                .Include(c => c.Cities).ToListAsync();
            return countries;
        }

        public async Task<Country?> GetSingleCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country is null)
                return null;

            return country;
        }
        public async Task<List<Country>> AddCountry(CountryDto request)
        {
            var newCountry = new Country
            {
                Name = request.Name
            };

            _context.Countries.Add(newCountry);
            await _context.SaveChangesAsync();
            return await _context.Countries.ToListAsync();
        }

        public async Task<List<Country>?> UpdateCountry(int id, CountryDto request)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country is null)
                return null;

            var newCountry = new Country
            {
                Name = request.Name
            };

            country.Name = newCountry.Name;

            await _context.SaveChangesAsync();

            return await _context.Countries.ToListAsync();
        }

        public async Task<List<Country>?> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country is null)
                return null;

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return await _context.Countries.ToListAsync();
        }
    }
}
