
using JuanWeb.DAL;
using JuanWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JuanWeb.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM vm = new HomeVM();
            vm.Sliders=_context.Sliders.ToList();
            vm.Products = _context.Products.ToList();
            return View(vm);
        }
    }
}
