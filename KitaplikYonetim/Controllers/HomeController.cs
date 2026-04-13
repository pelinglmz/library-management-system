using KitaplikYonetim.Data;
using KitaplikYonetim.Models;
using KitaplikYonetim.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace KitaplikYonetim.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context) => _context = context;

        public IActionResult Index()
        {
            var model = new DashboardVM
            {
                BookCount = _context.Books.Count(),
                AuthorCount = _context.Authors.Count(),
                CategoryCount = _context.Categories.Count(),

                // VERÝTABANINDAN YAYINEVÝ SAYISINI ÇEKÝYORUZ
                PublisherCount = _context.Publishers.Count(),

                RecentBooks = _context.Books
                    .Include(x => x.Category)
                    .Include(x => x.Author)
                    .OrderByDescending(x => x.Id)
                    .Take(5)
                    .ToList()
            };
            return View(model);
        }
    }
}
