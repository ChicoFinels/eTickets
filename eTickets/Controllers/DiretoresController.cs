using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class DiretoresController : Controller
    {
        private readonly AppDbContext _context;

        public DiretoresController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var diretores = await _context.Diretores.ToListAsync();
            return View(diretores);
        }
    }
}
