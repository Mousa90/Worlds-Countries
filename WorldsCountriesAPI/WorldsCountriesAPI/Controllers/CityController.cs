using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldsCountriesAPI.Models.Dto;
using WorldsCountriesAPI.Services.CityService;
using WorldsCountriesAPI.Services.UnitOfWork;


namespace WorldsCountriesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<City>>> GetAllCities()
        {
            return  _unitOfWork.City.GetAll().ToList();
        }

        [HttpGet("ByCountry")]
        public async Task<ActionResult<List<City>>> GetAllCitiesByCountry(int countryId)
        {
            return _unitOfWork.City.GetByCountryId(countryId).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetSingleCity(int id)
        {
            return _unitOfWork.City.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<City>> AddCity(City city)
        {
            var result= _unitOfWork.City.Add(city);
            _unitOfWork.Commit();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<City>> UpdateCity(int id, City request)
        {
            var result = _unitOfWork.City.GetById(id);
            if (result is null)
                return NotFound("City not found.");
            else
            {
                result = _unitOfWork.City.Update(request);
                _unitOfWork.Commit();
                return Ok(result);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<City>>> DeleteCity(int id)
        {
            var result = _unitOfWork.City.GetById(id);
            if (result is null)
                return NotFound("City not found.");
            else
            {
                _unitOfWork.City.Delete(result);
                _unitOfWork.Commit();
                return Ok();
            }
        }
    }
}
