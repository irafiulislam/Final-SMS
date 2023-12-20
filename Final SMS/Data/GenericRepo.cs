using Microsoft.EntityFrameworkCore;

namespace Final_SMS.Data
{
    public class GenericRepo
    {
 
        public class GenericRepository<T> : IGenericRepo<T> where T : class
        {
            protected readonly AppData _dataContext;
            public GenericRepository(AppData dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<T?> GetById(int id)
            {
                return await _dataContext.Set<T>().FindAsync(id);
            }

            public async Task<IList<T>> GetAll()
            {
                return await _dataContext.Set<T>().ToListAsync();
            }

            public async Task Add(T entity)
            {
                await _dataContext.Set<T>().AddAsync(entity);
                await _dataContext.SaveChangesAsync();
            }

            public async Task Update(T entity)
            {
                _dataContext.Set<T>().Update(entity);
                await _dataContext.SaveChangesAsync();
            }

            public async Task Delete(int id)
            {
                var result = await GetById(id);
                _dataContext.Set<T>().Remove(result);
            }
        }
    }


}
