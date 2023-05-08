using Customers.API.Interfaces;
using Customers.API.Models;

namespace Customers.API.Services
{
    public class UsersService : IUsersService
    {
        public UsersService()
        {
            
        }

        public async Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
