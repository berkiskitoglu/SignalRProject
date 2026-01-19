using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalR.DataAccessLayer.Repositories
{
    public class IGenericRepository<T> : IGenericDal<T> where T : class
    {
        protected readonly SignalRContext _context;

        public IGenericRepository(SignalRContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T enttiy)
        {
            _context.Remove(enttiy);
            _context.SaveChanges();
        }

        public T? GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
