using AutoMapper;
using OneRecipe.Application.DTOs;
using OneRecipe.Application.Interfaces;
using OneRecipe.Model.Interfaces;

namespace OneRecipe.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public UserDto Authenticate(string name, string password)
        {
            var user = this.repository.Authenticate(name, password);

            return user != null ? this.mapper.Map<UserDto>(user) : null;
        }
    }
}
