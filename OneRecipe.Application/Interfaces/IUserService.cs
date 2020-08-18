using OneRecipe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneRecipe.Application.Interfaces
{
    public interface IUserService
    {
        UserDto Authenticate(string name, string password);
    }
}
