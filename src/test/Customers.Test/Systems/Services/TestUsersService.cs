using Customers.Test.Helpers;
using Microsoft.Extensions.Options;
using Moq.Protected;
using Moq;
using Customers.Test.Fixtures;
using CustomersTDD.Domain.Models;
using CustomersTDD.Domain.Config;
using CustomersTDD.Application.Services;
using FluentAssertions;

namespace Customers.Test.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            var endpoint = "https://example.com/users";
            var config = Options.Create(new UsersApiOptions
            {
                Endpoint = endpoint
            });

            var sut = new UsersService(httpClient, config);

            //Act
            await sut.GetAllUsers();

            //Assert
            handlerMock
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Exactly(1),
                    ItExpr.Is<HttpRequestMessage>(request => request.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>()
                 );
        }

        [Fact]
        public async Task GetAllUsers_WhenHit404_ReturnsEmptyListOfUsers()
        {
            var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
            var httpClient = new HttpClient(handlerMock.Object);

            var endpoint = "https://example.com/users";
            var config = Options.Create(new UsersApiOptions
            {
                Endpoint = endpoint
            });

            var sut = new UsersService(httpClient, config);

            var result = await sut.GetAllUsers();

            result.Count.Should().Be(0);

        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsEmptyListOfUsersOfExpectedSize()
        {
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            var endpoint = "https://example.com/users";
            var config = Options.Create(new UsersApiOptions
            {
                Endpoint = endpoint
            });

            var sut = new UsersService(httpClient, config);

            var result = await sut.GetAllUsers();

            result.Count.Should().Be(expectedResponse.Count);

        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl()
        {
            var expectedResponse = UsersFixture.GetTestUsers();
            var endpoint = "https://example.com/users";
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse, endpoint);
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UsersApiOptions
            {
                Endpoint = endpoint
            });

            var sut = new UsersService(httpClient, config);

            var result = await sut.GetAllUsers();

            var uri = new Uri(endpoint);

            handlerMock
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Exactly(1),
                    ItExpr.Is<HttpRequestMessage>(request => request.Method == HttpMethod.Get && request.RequestUri == uri),
                    ItExpr.IsAny<CancellationToken>()
                 );
        }
    }
}
