using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Controllers
{
    public class HomeController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        // GET: Home/Index (Display books on the homepage)
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            return View(books); // Pass the books to the view
        }
    }
}
