using Microsoft.AspNetCore.Mvc;
using KitaplikYonetim.Data;
using KitaplikYonetim.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KitaplikYonetim.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;

        public AuthorController(AppDbContext context)
        {
            _context = context;
        }

        //LİSTELEME
        public IActionResult Index()
        {
            var authors = _context.Authors.ToList();
            return View(authors);
        }

        //CREATE
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Author author)
        {

            if (!string.IsNullOrEmpty(author.FullName))
            {
                _context.Authors.Add(author);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        //UPDATE
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null) return NotFound();
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (!string.IsNullOrEmpty(author.FullName))
            {
                _context.Authors.Update(author);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            // İlişkili kitap kontrolü
            var hasBooks = _context.Books.Any(b => b.AuthorId == id);

            if (hasBooks)
            {
                // Kullanıcıya neden silinmediğini bildiren mesaj
                TempData["Error"] = "Bu yazarı silemezsiniz! Bu yazara ait sistemde kayıtlı kitaplar bulunmaktadır. Önce kitapları silmelisiniz.";
                return RedirectToAction(nameof(Index));
            }

            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
                TempData["Success"] = "Yazar başarıyla silindi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}