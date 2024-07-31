namespace Imaginarium.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query();
    }
}
