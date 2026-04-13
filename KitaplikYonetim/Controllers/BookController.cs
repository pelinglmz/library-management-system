using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KitaplikYonetim.Data;
using KitaplikYonetim.Models.Entities;
using KitaplikYonetim.Models.ViewModels;

namespace KitaplikYonetim.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public BookController(AppDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // 1. LİSTELEME (Read)
        public IActionResult Index()
        {
            // Eager Loading: İlişkili tabloları tek bir sorguda getirir.
            var kitaplar = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToList();
            return View(kitaplar);
        }

        // 2. EKLEME - Sayfayı Açma
        public IActionResult Create()
        {
            // ViewModel kullanımı: View'a ihtiyaç duyduğu tüm listeleri tek bir paket olarak gönderir.
            return View(GetBookViewModel());
        }

        // 2. EKLEME - Veriyi Kaydetme
        [HttpPost]
        [ValidateAntiForgeryToken] // Güvenlik: CSRF saldırılarını engeller.
        public IActionResult Create(BookVM vm, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    vm.Book.ImagePath = UploadImage(file);
                }

                _context.Books.Add(vm.Book);
                _context.SaveChanges();
                TempData["Success"] = "Kitap başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }

            // Hata durumunda listeleri tekrar doldurup sayfayı geri döndürür.
            return View(GetBookViewModel(vm.Book));
        }

        // 3. DÜZENLEME (Update) - Sayfayı Açma
        public IActionResult Edit(int id)
        {
            var kitap = _context.Books.Find(id);
            if (kitap == null) return NotFound();

            return View(GetBookViewModel(kitap));
        }

        // 3. DÜZENLEME (Update) - Veriyi Güncelleme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookVM vm, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    vm.Book.ImagePath = UploadImage(file);
                }

                _context.Books.Update(vm.Book);
                _context.SaveChanges();
                TempData["Success"] = "Kitap başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }

            return View(GetBookViewModel(vm.Book));
        }

        // 4. SİLME
        public IActionResult Delete(int id)
        {
            var kitap = _context.Books.Find(id);
            if (kitap != null)
            {
                _context.Books.Remove(kitap);
                _context.SaveChanges();
                TempData["Success"] = "Kitap başarıyla silindi.";
            }
            return RedirectToAction(nameof(Index));
        }

        #region Yardımcı Metotlar (Private Helpers)

        // DRY Prensiibi: Liste doldurma işlemini merkezi bir yerden yönetir.
        private BookVM GetBookViewModel(Book? book = null)
        {
            return new BookVM
            {
                Book = book ?? new Book(),
                CategoryList = _context.Categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }),
                AuthorList = _context.Authors.Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }),
                PublisherList = _context.Publishers.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };
        }

        // Resim yükleme mantığını izole eder
        private string UploadImage(IFormFile file)
        {
            string dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string yol = Path.Combine(_webHost.WebRootPath, @"images\books");

            if (!Directory.Exists(yol)) Directory.CreateDirectory(yol);

            using (var stream = new FileStream(Path.Combine(yol, dosyaAdi), FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return @"\images\books\" + dosyaAdi;
        }

        #endregion
    }
}