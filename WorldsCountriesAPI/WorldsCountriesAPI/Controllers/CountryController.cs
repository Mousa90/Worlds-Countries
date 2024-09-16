using Microsoft.AspNetCore.Mvc;
using WorldsCountriesAPI.Services.UnitOfWork;

namespace WorldsCountriesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAllCountries()
        {
            return _unitOfWork.Country.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetSingleCountry(int id)
        {
            return _unitOfWork.Country.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> AddCountry(Country country)
        {
            var result = _unitOfWork.Country.Add(country);
            _unitOfWork.Commit();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Country>> UpdateCountry(int id, Country request)
        {
            var result = _unitOfWork.Country.GetById(id);
            if (result is null)
                return NotFound("Country not found.");
            else
            {
                result = _unitOfWork.Country.Update(request);
                _unitOfWork.Commit();
                return Ok(result);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Country>>> DeleteCountry(int id)
        {
            var result = _unitOfWork.Country.GetById(id);
            if (result is null)
                return NotFound("Country not found.");
            else
            {
                _unitOfWork.Country.Delete(result);
                _unitOfWork.Commit();
                return Ok();
            }
        }
    }
}
