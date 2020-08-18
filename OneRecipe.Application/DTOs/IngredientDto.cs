namespace OneRecipe.Application.DTOs
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int RecipeId { get; set; }

        #region 'Navigation'
        public virtual RecipeDto Recipe { get; set; }

        #endregion
    }
}
