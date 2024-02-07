﻿using OrderNow.Common.Data.Entities;

namespace OrderNow.Tests.Services
{
    public class UsersServices_Tests
    {
        private readonly UsersServices _sut;
        private readonly UserManager<User> _userManager;
        private readonly Mock<IUsersRepository> _userRepositoryMock = new Mock<IUsersRepository>();

        public UsersServices_Tests()
        {
            _sut = new UsersServices(_userRepositoryMock.Object, _userManager);
        }

        [Fact]
        public void AddProductToOrder_ShouldAddAProductToAnOrder_WhenProductAndOrderExists()
        {
            //UsersServices _sut = new UsersServices();

            var user = new User();
            var product = new Product();
            var order = new Order();
            //Act
            var result = _sut.AddProductToOrder(user, order, product);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AssingAFavoriteBusinessToAUser()
        {
            var relation = new UserBusiness();
            //Act
            var result = await _sut.SetFavoriteBusinessesByUserAsync("", "");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AssingAFavoriteProductToAUser()
        {
            // UsersServices _sut = new UsersServices();
            var user = new User();
            var product = new Product();
            //Act
            var result = _sut.AssignFavoriteProductsToUsers(user, product);

            //Assert
            Assert.True(result);
        }

        //Agregar producto a orden

        /// <summary>
        /// CU -
        /// </summary>
        ///

        [Theory]
        [InlineData("epolicardo@gmail.com", "pizzeria-popular-rc")]
        public async Task GetFavoriteBusinessesByUser_ShouldRetrieveListOfBusinesses_WhenUserHasFavoriteBusinesses(string email, string expected)
        {
            var user = new User()
            {
                Email = email,
                Id = It.IsAny<string>(),
            };

            this._userRepositoryMock.Setup(x => x.GetFavoriteBusinessesByUserAsync(user.Email)).ReturnsAsync(new List<UserBusiness>()
            {
                new UserBusiness
                {
                    Business = new Business()
                    {
                        ContractURL = expected,
                    },
                    User = user
                }
            });
            var response = await _sut.GetFavoriteBusinessesByUserAsync(user.Email);

            var result = response.FirstOrDefault(x => x.User.Email == email).Business.ContractURL;

            response.Should().NotBeNull();
            result.Should().Be(expected);
        }

        //Editar producto en orden
        //Finalizar pedido (Se completa la orden, se envia al comercio y se guardan en mis compras)

        [Fact]
        public void ValidateUser()
        {
            System.Console.WriteLine();
            //https://docs.microsoft.com/en-us/aspnet/mvc/overview/security/create-an-aspnet-mvc-5-web-app-with-email-confirmation-and-password-reset
        }
    }
}