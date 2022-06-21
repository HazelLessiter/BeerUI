using BeerUI.Configuration;
using BeerUIApp.Models;
using BeerUIApp.UseCases;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BeerUIApp
{
    public class BeerUseCase : IBeerUseCase
    {
        private readonly HttpClient _client;
        private readonly PunkAPIConfiguration _punkAPIComnfiguration;

        public BeerUseCase(HttpClient client,
            IOptions<PunkAPIConfiguration> punkAPIConfiguration)
        {
            _client = client;
            _punkAPIComnfiguration = punkAPIConfiguration.Value;
        }

        public List<Beer> GetBeer(int pageNumber)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_punkAPIComnfiguration.BaseURL}beers?page={pageNumber}&per_page=15")
            };

            var response = _client.SendAsync(httpRequestMessage).Result;

            var json = response.Content.ReadAsStringAsync()
               .Result;

            return JsonConvert.DeserializeObject<List<Beer>>(json);
        }

        public List<Beer> GetBeer(string name)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_punkAPIComnfiguration.BaseURL}beers?beer_name={name}")
            };

            var response = _client.SendAsync(httpRequestMessage).Result;

            var json = response.Content.ReadAsStringAsync()
               .Result;

            return JsonConvert.DeserializeObject<List<Beer>>(json);
        }
    }
}
