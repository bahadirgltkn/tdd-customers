using Customers.API.Controllers;
using Customers.API.Interfaces;
using Customers.API.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Customers.Test.Systems.Controllers
{
    public class TestUsersController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange
            //Arrange
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUsersService.Object);

            //Act
            var result = (OkObjectResult)await sut.Get();

            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokesUsersServiceExactlyOnce()
        {
            //Arrange
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUsersService.Object);

            //Act
            var result = await sut.Get();

            //Assert
            mockUsersService.Verify(service => service.GetAllUsers(), Times.Once());
        }
    }
}