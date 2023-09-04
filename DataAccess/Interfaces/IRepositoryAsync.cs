namespace Test.DataAccess.Interfaces
{
    public interface IRepositoryAsync<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<bool> Delete(int id);
        Task<bool> Update(T entity);        
    }
}
