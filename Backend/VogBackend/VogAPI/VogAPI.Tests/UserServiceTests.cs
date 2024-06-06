using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Interface;
using Moq;
using VogAPI.Models;

namespace VogAPI.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetUserByEmailAndPasswordAsync_ValidCredentials_ReturnsUserResponse()
        {
            // Arrange
            var email = "test@example.com";
            var password = "password123";

            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockUserRepository.Object);

            var user = new User
            {
                Id = 1,
                Username = "testuser"
            };

            mockUserRepository.Setup(repo => repo.GetUserByEmailAndPasswordAsync(email, password))
                              .ReturnsAsync(user);

            // Act
            var result = await userService.GetUserByEmailAndPasswordAsync(email, password);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Username, result.Username);
        }

        [Fact]
        public async Task GetUserByEmailAndPasswordAsync_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            var email = "test@example.com";
            var password = "password123";

            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockUserRepository.Object);

            mockUserRepository.Setup(repo => repo.GetUserByEmailAndPasswordAsync(email, password))
                              .ReturnsAsync((User)null);

            // Act
            var result = await userService.GetUserByEmailAndPasswordAsync(email, password);

            // Assert
            Assert.Null(result);
        }
    }
}