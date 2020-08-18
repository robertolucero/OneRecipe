using System.Collections.Generic;

namespace OneRecipe.Application.DTOs
{
    public class RecipeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ICollection<IngredientDto> Ingredients { get; set; }
    }
}
