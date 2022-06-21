using BeerUI.Models;
using BeerUIApp.Models;
using BeerUIApp.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BeerUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBeerUseCase _beerUseCase;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IBeerUseCase beerUseCase,
            ILogger<HomeController> logger)
        {
            _beerUseCase = beerUseCase;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Beer()
        {
            var beers = _beerUseCase.GetBeer(1);

            return View(beers);
        }

        [HttpPost]
        public ActionResult Next(List<Beer> beers)
        {
            var pageNumber = beers.FirstOrDefault().PageNumer++;

            beers = _beerUseCase.GetBeer(pageNumber);

            beers.FirstOrDefault().PageNumer = pageNumber;

            return View("Beer", beers);
        }

        [HttpPost]
        public ActionResult Previous(List<Beer> beers)
        {
            var pageNumber = beers.FirstOrDefault().PageNumer--;

            beers = _beerUseCase.GetBeer(pageNumber);

            beers.FirstOrDefault().PageNumer = pageNumber;

            return View("Beer", beers);
        }

        [HttpGet]
        public ActionResult Search(string name)
        {
            var beers = _beerUseCase.GetBeer(name);

            return View("Beer", beers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}