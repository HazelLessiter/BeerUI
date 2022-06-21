using BeerUIApp.Models;

namespace BeerUIApp.UseCases
{
    public interface IBeerUseCase
    {
        public List<Beer> GetBeer(int pageNumber);
        public List<Beer> GetBeer(string name);
    }
}