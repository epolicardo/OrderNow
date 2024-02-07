namespace OrderNow.Tests.RepositoriesTest
{
    public class UsersShould
    {
        private readonly DataContext _dataContext;
        private readonly Mock<IDateTimeProvider> _dateTimeProvider;
        private readonly UsersRepository _sut;
        //[Fact]
        //public async Task AddRelationWithBusiness()
        //{
        //    Business business = new Business()
        //    {
        //        Id = It.IsAny<Guid>(),
        //        Name = It.IsAny<string>(),
        //        Created = It.IsAny<DateTime>(),
        //    };

        //    Users user = new Users()
        //    {
        //        Id = It.IsAny<string>(),
        //        UserName = It.IsAny<string>(),
        //    };
        //    await _sut.AddRelationUserBusiness(user, business);
        //}

        [Fact]
        public void GetByIdAsync_Returns_Product()
        {
            //Setup DbContext and DbSet mock
            var dbContextMock = new Mock<DataContext>();
            var dbSetMock = new Mock<DbSet<User>>();
            dbSetMock.Setup(s => s.FindAsync(It.IsAny<string>())).ReturnsAsync((new User()));
            dbContextMock.Setup(s => s.Set<User>()).Returns(dbSetMock.Object);

            //Execute method of SUT (ProductsRepository)
            var usersRepository = new UsersRepository(dbContextMock.Object, _dateTimeProvider.Object);
            var user = usersRepository.GetByIdAsync(Guid.NewGuid()).Result;

            //Assert
            Assert.NotNull(user);
            Assert.IsAssignableFrom<User>(user);
        }
    }
}