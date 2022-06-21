using BeerUIApp.UseCases;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;

namespace BeerUI.Tests
{
    public class GetBeersTest
    {
        private TestServerFixture _testServerFixture;
        private IBeerUseCase _beerUseCase;

        public GetBeersTest()
        {
            _testServerFixture = new TestServerFixture();
            _beerUseCase = _testServerFixture.Host.Services.GetService<IBeerUseCase>();
        }

        [Fact]
        public void GetBeers()
        {
            //Arrange
            var expectedCount = 15;

            //Act
            var beers = _beerUseCase.GetBeer(1);

            //Assert
            Assert.NotNull(beers);
            Assert.Equal(expectedCount, beers.Count());
        }
    }
}
