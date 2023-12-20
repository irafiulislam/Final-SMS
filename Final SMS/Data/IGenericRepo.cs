namespace Final_SMS.Data
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IList<T>>GetAll();
        Task<T?> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);

    }
}
