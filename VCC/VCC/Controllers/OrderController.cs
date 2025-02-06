using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VCC.Models;

namespace VCC.Controllers
{
    public class OrderController : Controller
    {
        private AppDbContext context;
        public OrderController(AppDbContext ac)
        {
            context = ac;
        }

        public IActionResult Index()
        {
            return View(context.Order.AsNoTracking());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            context.Add(order);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Order order = await context.Order.Where(e => e.Id == id).FirstOrDefaultAsync();
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Order order)
        {
            context.Update(order);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
