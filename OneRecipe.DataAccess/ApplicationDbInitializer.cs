using Microsoft.EntityFrameworkCore;
using OneRecipe.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneRecipe.DataAccess
{
    public static class ApplicationDbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Name = "Spaghetti and meatballs",
                    Description = "It's already no-fuss, but throwing everything into a slow cooker makes it even better and easier!",
                    ImagePath = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/crock-pot-spaghetti-horizontal-jpg-1522721232.jpg?crop=1xw:1xh;center,top&resize=768:*",
                    Directions = "1. Make meatballs: In a large bowl, mix together ground beef, bread crumbs, Parmesan, parsley, egg, salt, and crushed red pepper flakes. Form into 16 meatballs and place in the bottom of a Crock Pot." +
                                "2. In another large bowl, mix together crushed tomatoes, tomato paste, onion, oregano, and garlic. Season with salt, pepper and a pinch of red pepper flakes. Pour sauce over meatballs. Cover Crock Pot with lid and cook on high for 3 hours or on low for 5 hours." +
                                "3. Add broth spaghetti to Crock Pot, breaking noodles in half to fit and stirring to coat noodles. Replace lid and continue cooking on low for 1 1/2 hour more hours, stirring about every 30 minutes and breaking up any clumps of noodles and adding more broth as needed." +
                                "4. Garnish with Parmesan and parsley before serving."

                }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, RecipeId = 1, Name = "ground beef", Amount = 1 },
                new Ingredient { Id = 2, RecipeId = 1, Name = "bread crumbs", Amount = 1.25M },
                new Ingredient { Id = 3, RecipeId = 1, Name = "freshly grated parmesan", Amount = 1.25M },
                new Ingredient { Id = 4, RecipeId = 1, Name = "large egg, beaten", Amount = 1 },
                new Ingredient { Id = 5, RecipeId = 1, Name = "cloves garlic, minced", Amount = 2 },
                new Ingredient { Id = 6, RecipeId = 1, Name = "freshly chopped parsley", Amount = 1.25M }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "test@test.com", Password = "test" }
            );
        }
    }
}
