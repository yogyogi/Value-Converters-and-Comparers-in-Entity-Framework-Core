using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VCC.Models;

namespace VCC.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext context;
        public ProductController(AppDbContext ac)
        {
            context = ac;
        }

        public IActionResult Index()
        {
            return View(context.Product.AsNoTracking());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            context.Add(product);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Product product = await context.Product.Where(e => e.Id == id).FirstOrDefaultAsync();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            context.Update(product);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
