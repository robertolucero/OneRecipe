using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OneRecipe.Application.Interfaces;
using OneRecipe.Controllers;
using System;
using System.Threading.Tasks;

namespace OneRecipe.Tests
{
    [TestClass]
    public class RecipeControllerTest
    {
        [TestMethod]
        public void IfUnhandledExceptionIsThrown_ShouldBeHandledByExceptionMiddleware()
        {
            //arrange
            var mockRecipeService = new Mock<IRecipeService>();
            mockRecipeService.Setup(m => m.GetAllRecipesAsync())
                .ThrowsAsync(new Exception("Unhandled Exception"));

            var controller = new RecipeController(mockRecipeService.Object);

            //assert
            var ex = Assert.ThrowsExceptionAsync<Exception>(async () => 
            {
                await controller.GetRecipesAsync();
            });

        }
    }
}
