using OneRecipe.Model;
using OneRecipe.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneRecipe.DataAccess.Repositories
{
    public class IngredientRepository : IGenericRepository<Ingredient>
    {
        public Ingredient Create(Ingredient recipe)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Ingredient recipe)
        {
            throw new NotImplementedException();
        }

        public void Delete(Ingredient recipe)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Ingredient recipe)
        {
            throw new NotImplementedException();
        }

        public Ingredient Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Ingredient Update(Ingredient recipe)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Ingredient recipe)
        {
            throw new NotImplementedException();
        }
    }
}
