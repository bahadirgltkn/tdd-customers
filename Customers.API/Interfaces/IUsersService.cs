using Customers.API.Models;

namespace Customers.API.Interfaces
{
    public interface IUsersService
    {
        Task<List<User>> GetAllUsers();
    }
}
