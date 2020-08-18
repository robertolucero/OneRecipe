using Microsoft.EntityFrameworkCore;
using OneRecipe.Model;
using OneRecipe.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneRecipe.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public User Authenticate(string email, string password)
        {
            return this.context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
