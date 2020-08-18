using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneRecipe.Model
{
    [Table("Recipe")]
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }

        public string Directions { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string ImagePath { get; set; }

        #region 'Navigation
        public ICollection<Ingredient> Ingredients { get; set; }

        #endregion
    }
}
