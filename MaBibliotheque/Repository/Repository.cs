using MaBibliotheque.Data;
using MaBibliotheque.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Windows.Themes;

namespace MaBibliotheque.Repository
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
    {
        private readonly AppDbContext _context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T GetById(int id) => _dbSet.Find(id);

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
