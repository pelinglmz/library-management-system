using Microsoft.AspNetCore.Mvc;
using KitaplikYonetim.Data;
using KitaplikYonetim.Models.Entities;
using System.Linq;

namespace KitaplikYonetim.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name != null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // delete
        public IActionResult Delete(int id)
        {
            // Kategoriye ait kitap var mı kontrol et
            var hasBooks = _context.Books.Any(b => b.CategoryId == id);

            if (hasBooks)
            {
                TempData["Error"] = "Bu kategoriyi silemezsiniz! Bu kategoriye ait kayıtlı kitaplar bulunmaktadır.";

                return RedirectToAction("Index", "Category");
            }

            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                TempData["Success"] = "Kategori başarıyla silindi.";
            }

            return RedirectToAction("Index", "Category");
        }
    }
}