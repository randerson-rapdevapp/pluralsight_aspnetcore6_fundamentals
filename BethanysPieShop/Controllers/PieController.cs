using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            this._pieRepository = pieRepository;
            this._categoryRepository = categoryRepository;
        }
        public IActionResult List(string category)
        {
            IEnumerable<Pie> pies;
            string? currentCategory;

            if (String.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies;
                currentCategory = "All pies";
            }
            else
            {
                currentCategory = category;
                pies = _pieRepository.AllPies.Where(w => w.Category.CategoryName == currentCategory).OrderBy(pie => pie.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(cat => cat.CategoryName == category)?.CategoryName;
            }

            var vm = new PieListViewModel(currentCategory, pies);
            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var pie = this._pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();
            return View(pie);
        }
    }
}
