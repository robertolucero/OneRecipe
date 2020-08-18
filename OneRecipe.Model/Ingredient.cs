using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OneRecipe.Model
{
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        #region 'Navigation'
        public virtual Recipe Recipe { get; set; }

        #endregion
    }
}
