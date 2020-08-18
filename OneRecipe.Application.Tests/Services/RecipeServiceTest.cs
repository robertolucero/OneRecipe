using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OneRecipe.Application.DTOs;
using OneRecipe.Model;
using OneRecipe.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneRecipe.Application.Tests.Services
{
    [TestClass]
    public class RecipeServiceTest
    {

        [TestMethod]
        public void ShouldCreateARecipe()
        { 
            //arrange
            var databaseRecipes = new List<Recipe>
            {
                new Recipe { Id = 1, Name = "Spaghetti and meatballs",
                            Description = "It's already no-fuss, but throwing everything into a slow cooker makes it even better and easier!",
                            Directions = "Preparations steps"}
            };

            var newRecipeDto = new RecipeDto { Name = "Rare beef steak with herb garlic butter", ImagePath = "http://somerurl.com" };
            var newRecipe = new Recipe { Name = "Rare beef steak with herb garlic butter", ImagePath = "http://somerurl.com" };

            var mockRecipeRepository = new Mock<IGenericRepository<Recipe>>();
            //mockRecipeRepository.Setup(m => m.GetAll()).Returns(databaseRecipes);
            mockRecipeRepository.Setup(m => m.CreateAsync(newRecipe)).Callback(() => databaseRecipes.Add(newRecipe));


            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Recipe>(newRecipeDto)).Returns(newRecipe);

            var service = new RecipeService(mockRecipeRepository.Object, mapperMock.Object);

            //act
            var result = service.CreateRecipeAsync(newRecipeDto);

            //assert
            Assert.AreEqual(2, databaseRecipes.Count);
        }
    }
}
