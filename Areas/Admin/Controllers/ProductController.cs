using JuanWeb.Controllers;
using JuanWeb.DAL;
using JuanWeb.Models;
using JuanWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JuanWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        AppDbContext _context;
        HomeVM vm = new HomeVM();

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            vm.Products=_context.Products.ToList();
            vm.Sliders = _context.Sliders.ToList();
            return View(vm);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("Product", "Melumat tapilmadi");
            }
            var prod=_context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(prod);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var uprod= _context.Products.FirstOrDefault(x=>x.Id == id);
            return View(uprod);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (!ModelState.IsValid) 
            { ModelState.AddModelError("Product", "Melumat tapilmadi"); }
            var prod=_context.Products.FirstOrDefault(y => y.Id == product.Id);
            prod.Name=product.Name;
            prod.Price=product.Price;
            prod.Description=product.Description;
            prod.ImgUrl=product.ImgUrl;
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
