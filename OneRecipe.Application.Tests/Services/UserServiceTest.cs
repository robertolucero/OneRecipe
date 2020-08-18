using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OneRecipe.Application.DTOs;
using OneRecipe.Application.Services;
using OneRecipe.Model;
using OneRecipe.Model.Interfaces;

namespace OneRecipe.Application.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void IfUserIsAutenticated_ShouldReturnValidUser()
        {
            //arrange
            var validUser = new User { Id = 1, Email = "dummyUser@dummy.com", Password = "123456" };

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(m => m.Authenticate("dummyUser@dummy.com", "123456")).Returns(validUser);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<UserDto>(validUser)).Returns(new UserDto { Email = "dummyUser", Password = "123456" });

            var service = new UserService(mockUserRepository.Object, mapperMock.Object);

            //act
            var userDto = service.Authenticate("dummyUser@dummy.com", "123456");

            //assert
            Assert.AreEqual("dummyUser", userDto.Email);
            Assert.AreEqual("123456", userDto.Password);

        }

        [TestMethod]
        public void IfUserIsNotAutenticated_ShouldReturnNull()
        {
            //arrange
            var validUser = new User { Id = 1, Email = "dummyUser@dummy.com", Password = "123456" };

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(m => m.Authenticate("dummyUser", "123456")).Returns(validUser);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<UserDto>(validUser)).Returns(new UserDto { Email = "dummyUser", Password = "123456" });

            var service = new UserService(mockUserRepository.Object, mapperMock.Object);

            //act
            var userDto = service.Authenticate("anotherDummyUser@dummy.com", "123456");

            //assert
            Assert.IsNull(userDto);
        }

    }
}
