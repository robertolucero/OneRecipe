using Microsoft.EntityFrameworkCore;
using OneRecipe.Model;
using OneRecipe.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneRecipe.DataAccess.Repositories
{
    public class RecipeRepository : IGenericRepository<Recipe>
    {
        private ApplicationDbContext context;
        public RecipeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        #region 'Synchronous'
        public Recipe Get(int id)
        {
            return context.Recipes.SingleOrDefault(recipe => recipe.Id == id);
        }

        public void Delete(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe Update(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe Create(Recipe recipe)
        {
            context.Recipes.Add(recipe);
            context.SaveChanges();
            return recipe;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return context.Recipes;
        }

        #endregion

        #region 'Asynchronous'

        public Task<Recipe> GetAsync(int id)
        {
            return context.Recipes.SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await context.Recipes
                .Include(r => r.Ingredients)
                .ToListAsync();
        }

        public async Task CreateAsync(Recipe recipe)
        {
            context.Recipes.Add(recipe);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            await UpdateIngredients(recipe.Ingredients, recipe.Id);

            context.Entry(recipe).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Recipe recipe)
        {
            context.Recipes.Remove(recipe);

            await context.SaveChangesAsync();
        }

        private Task UpdateIngredients(IEnumerable<Ingredient> ingredients, int recipeId)
        {
            return Task.Run(() =>
            {
                var oldIngredients = context.Ingredients.Where(i => i.RecipeId == recipeId);
                if (oldIngredients.Any())
                {
                    context.Ingredients.RemoveRange(oldIngredients);
                    context.SaveChanges();
                }

                if (ingredients.Any())
                {
                    foreach (var ingredient in ingredients)
                    {
                        context.Ingredients.Add(new Ingredient
                        {
                            Name = ingredient.Name,
                            Amount = ingredient.Amount,
                            RecipeId = recipeId
                        });
                    }

                    context.SaveChanges();
                }
            });
        }
        #endregion
    }
}
