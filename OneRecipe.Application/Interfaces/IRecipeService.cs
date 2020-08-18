using OneRecipe.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneRecipe.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
        Task CreateRecipeAsync(RecipeDto recipe);
        Task UpdateRecipeAsync(RecipeDto recipe);
        Task DeleteRecipeAsync(int recipeId);

    }
}
