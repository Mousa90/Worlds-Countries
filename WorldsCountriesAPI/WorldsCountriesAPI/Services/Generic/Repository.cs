
using System.Security.Cryptography.Xml;

namespace WorldsCountriesAPI.Services.Generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
           return _context.Set<T>().Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            return _context.Set<T>().Update(entity).Entity;
        }
    }
}
