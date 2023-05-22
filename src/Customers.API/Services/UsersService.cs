using Customers.API.Config;
using Customers.API.Interfaces;
using Customers.API.Models;
using Microsoft.Extensions.Options;

namespace Customers.API.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient HttpClient;
        private readonly UsersApiOptions ApiConfig;

        public UsersService(HttpClient httpClient, IOptions<UsersApiOptions> apiConfig)
        {
            HttpClient = httpClient;
            ApiConfig = apiConfig.Value;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var usersResponse = await HttpClient.GetAsync(ApiConfig.Endpoint);

            if(usersResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<User>();

            var responseContent = usersResponse.Content;
            var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();

            return allUsers.ToList();
        }
    }
}
