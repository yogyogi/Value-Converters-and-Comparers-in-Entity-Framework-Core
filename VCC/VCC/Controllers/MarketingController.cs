using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VCC.Models;

namespace VCC.Controllers
{
    public class MarketingController : Controller
    {
        private AppDbContext context;
        public MarketingController(AppDbContext ac)
        {
            context = ac;
        }

        public IActionResult Index()
        {
            return View(context.Marketing.AsNoTracking());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Marketing marketing)
        {
            context.Add(marketing);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Marketing marketing = await context.Marketing.Where(e => e.Id == id).FirstOrDefaultAsync();
            return View(marketing);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Marketing marketing)
        {
            context.Update(marketing);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
