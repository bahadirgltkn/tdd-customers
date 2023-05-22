using Customers.API.Models;

namespace Customers.Test.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() => new()
        {
            new User
            {
                Name = "Test User 1",
                Email = "test.user.1@mail",
                Address = new Address
                {
                    Street = "123 St",
                    City = "Istanbul",
                    ZipCode = "34001"

                }
            },
            new User
            {
                Name = "Test User 2",
                Email = "test.user.2@mail",
                Address = new Address
                {
                    Street = "1234 St",
                    City = "Istanbul",
                    ZipCode = "34002"

                }
            },
            new User
            {
                Name = "Test User 3",
                Email = "test.user.3@mail",
                Address = new Address
                {
                    Street = "125 St",
                    City = "Istanbul",
                    ZipCode = "34003"

                }
            },
        };
    }
}
