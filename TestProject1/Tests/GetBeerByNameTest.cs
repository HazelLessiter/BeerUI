using BeerUIApp.UseCases;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;

namespace BeerUI.Tests
{
    public class GetBeerByNameTest
    {
        private TestServerFixture _testServerFixture;
        private IBeerUseCase _beerUseCase;

        public GetBeerByNameTest()
        {
            _testServerFixture = new TestServerFixture();
            _beerUseCase = _testServerFixture.Host.Services.GetService<IBeerUseCase>();
        }

        [Fact]
        public void GetBeerByName()
        {
            //Arrange
            var name = "Buzz";

            //Act
            var beers = _beerUseCase.GetBeer(name);

            //Assert
            Assert.NotNull(beers);
            Assert.Equal(name, beers.FirstOrDefault().Name);
        }
    }
}
