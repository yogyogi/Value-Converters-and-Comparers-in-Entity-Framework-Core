using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VCC.Models;

namespace VCC.Controllers
{
    public class StudentController : Controller
    {
        private AppDbContext context;
        public StudentController(AppDbContext ac)
        {
            context = ac;
        }

        public IActionResult Index()
        {
            return View(context.Student.AsNoTracking());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            context.Add(student);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Student student = await context.Student.Where(e => e.Id == id).FirstOrDefaultAsync();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student student)
        {
            context.Update(student);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
