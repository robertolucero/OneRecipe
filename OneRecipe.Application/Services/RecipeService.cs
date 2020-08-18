using AutoMapper;
using OneRecipe.Application.DTOs;
using OneRecipe.Application.Interfaces;
using OneRecipe.DataAccess.Repositories;
using OneRecipe.Model;
using OneRecipe.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneRecipe.Application
{
    public class RecipeService : IRecipeService
    {
        private readonly IGenericRepository<Recipe> repository;
        private readonly IMapper mapper;
        public RecipeService(IGenericRepository<Recipe> recipeRepository, IMapper mapper)
        {
            this.repository = recipeRepository;
            this.mapper = mapper;
        }

        public async Task CreateRecipeAsync(RecipeDto recipe)
        {
            var recipesModel = mapper.Map<Recipe>(recipe);
            await repository.CreateAsync(recipesModel);
        }

        public async Task DeleteRecipeAsync(int recipeId)
        {
            var recipe = await repository.GetAsync(recipeId);
            await repository.DeleteAsync(recipe);
        }

        public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync()
        {
            var recipes = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<RecipeDto>>(recipes);
        }

        public async Task UpdateRecipeAsync(RecipeDto recipe)
        {
            var recipesModel = mapper.Map<Recipe>(recipe);
            await repository.UpdateAsync(recipesModel);
        }
    }
}
