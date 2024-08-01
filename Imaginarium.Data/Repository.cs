using Imaginarium.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Imaginarium.Domain
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _table;

        public Repository(ImaginariumDbContext context)
        {
            _table = context.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return _table.AsQueryable();
        }
    }
}
