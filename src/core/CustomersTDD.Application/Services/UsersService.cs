using CustomersTDD.Application.Interfaces;
using CustomersTDD.Domain.Config;
using CustomersTDD.Domain.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CustomersTDD.Application.Services
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

            if (usersResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<User>();

            var responseContent = usersResponse.Content;
            var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();

            return allUsers.ToList();
        }
    }
}
