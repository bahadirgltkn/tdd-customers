using CustomersTDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersTDD.Application.Interfaces
{
    public interface IUsersService
    {
        Task<List<User>> GetAllUsers();
    }
}
