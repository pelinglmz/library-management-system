using Microsoft.AspNetCore.Mvc;
using KitaplikYonetim.Data;
using KitaplikYonetim.Models.Entities;
using System.Linq;

namespace KitaplikYonetim.Controllers
{
    public class PublisherController : Controller
    {
        private readonly AppDbContext _context;

        public PublisherController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var publishers = _context.Publishers.ToList();
            return View(publishers);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Publisher publisher)
        {
            if (!string.IsNullOrEmpty(publisher.Name))
            {
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var publisher = _context.Publishers.Find(id);
            return View(publisher);
        }

        [HttpPost]
        public IActionResult Edit(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var hasBooks = _context.Books.Any(b => b.PublisherId == id);
            if (hasBooks)
            {
                TempData["Error"] = "Bu yayınevine ait kitaplar olduğu için silemezsiniz!";
                return RedirectToAction(nameof(Index));
            }

            var publisher = _context.Publishers.Find(id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}