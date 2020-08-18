using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneRecipe.Application.DTOs;
using OneRecipe.Application.Interfaces;

namespace OneRecipe.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService service;
        public RecipeController(IRecipeService service)
        {
            this.service = service;
        }
        #region 'Asynchronous endpoints'

        /// <summary>
        /// Returns all recipes.
        /// </summary>
        /// <returns>RecipeDto list.</returns>
        [HttpGet("GetRecipesAsync")]
        public async Task<IActionResult> GetRecipesAsync()
        {
            var recipes = await service.GetAllRecipesAsync();

            return Ok(recipes);
        }

        /// <summary>
        /// Create a new recipe
        /// </summary>
        /// <param name="recipe">Recipe to create</param>
        /// <returns></returns>
        [HttpPost("CreateRecipeAsync")]
        public async Task<IActionResult> CreateRecipeAsync(RecipeDto recipe)
        {
            await service.CreateRecipeAsync(recipe);

            return Ok();
        }

        /// <summary>
        /// Create a new recipe
        /// </summary>
        /// <param name="recipe">Recipe to create</param>
        /// <returns></returns>
        [HttpPut("UpdateRecipeAsync")]
        public async Task<IActionResult> UpdateRecipeAsync(RecipeDto recipe)
        {
            
            await service.UpdateRecipeAsync(recipe);

            return Ok();
        }

        /// <summary>
        /// Deletes a recipe
        /// </summary>
        /// <param name="recipeId">Recipe ID to delete</param>
        /// <returns></returns>
        [HttpDelete("DeleteRecipeAsync")]
        public async Task<IActionResult> DeleteRecipeAsync(int recipeId)
        {

            await service.DeleteRecipeAsync(recipeId);

            return Ok();
        }
        #endregion

    }
}
