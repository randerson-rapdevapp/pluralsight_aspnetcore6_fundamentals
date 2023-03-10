using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            this._pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel(_pieRepository.PiesOfTheWeek);
            return View(vm);
        }
    }
}
