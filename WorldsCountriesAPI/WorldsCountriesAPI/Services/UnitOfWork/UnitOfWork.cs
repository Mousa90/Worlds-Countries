using WorldsCountriesAPI.Services.CityService;
using WorldsCountriesAPI.Services.Generic;

namespace WorldsCountriesAPI.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Country> Country { get; private set; }

        public IRepositoryCity City { get; private set; }

        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context=context;
            Country = new Repository<Country>(context);
            City = new RepositoryCity(context);
        }
        void IUnitOfWork.Commit()
        {
            _context.SaveChanges();
        }
    }
}
