namespace Imaginarium.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query();
    }
}
