using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneRecipe.Model.Interfaces
{
    public interface IUserRepository
    {
        User Authenticate(string email, string password);

    }
}
