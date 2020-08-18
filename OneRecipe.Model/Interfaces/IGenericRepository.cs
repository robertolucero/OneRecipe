using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneRecipe.Model.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        #region 'Synchronous'
        T Get(int id);
        IEnumerable<T> GetAll();
        T Create(T recipe);
        T Update(T recipe);
        void Delete(T recipe);

        #endregion

        #region 'Asynchronous'

        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T recipe);
        Task UpdateAsync(T recipe);
        Task DeleteAsync(T recipe);

        #endregion
    }
}
