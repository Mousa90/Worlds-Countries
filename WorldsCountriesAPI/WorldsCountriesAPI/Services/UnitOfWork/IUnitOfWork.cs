using WorldsCountriesAPI.Services.CityService;
using WorldsCountriesAPI.Services.Generic;

namespace WorldsCountriesAPI.Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Country> Country { get; }
        IRepositoryCity City { get; } // Custom Repository

        void Commit();
        
    }
}
