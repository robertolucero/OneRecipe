using AutoMapper;
using OneRecipe.Application.DTOs;
using OneRecipe.Model;

namespace OneRecipe.Application.AutoMapper
{
    public class MappingsProfile: Profile
    {
        public MappingsProfile()
        {
            CreateMap<Recipe, RecipeDto>().ReverseMap();
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }

    }
}
