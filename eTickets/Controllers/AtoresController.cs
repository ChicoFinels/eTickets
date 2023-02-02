using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class AtoresController : Controller
    {
        private readonly AppDbContext _context;

        public AtoresController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var atores = await _context.Atores.ToListAsync();
            return View(atores);
        }
    }
}
