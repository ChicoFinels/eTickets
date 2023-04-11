using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class FilmesController : Controller
    {
        private readonly IFilmeService _service;

        public FilmesController(IFilmeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var filmes = await _service.ObterTodos(n=>n.Cinema);
            return View(filmes);
        }

        //GET: Filmes/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }
    }
}
