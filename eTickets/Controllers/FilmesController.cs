using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Nome");
            ViewBag.Diretores = new SelectList(movieDropdownsData.Diretores, "Id", "Nome");
            ViewBag.Atores = new SelectList(movieDropdownsData.Atores, "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Nome");
                ViewBag.Diretores = new SelectList(movieDropdownsData.Diretores, "Id", "Nome");
                ViewBag.Atores = new SelectList(movieDropdownsData.Atores, "Id", "Nome");

                return View(movie);
            }

            await _service.AdicionarFilme(movie);
            return RedirectToAction(nameof(Index));
        }

        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new CreateMovie()
            {
                Id = movieDetails.Id,
                Nome = movieDetails.Nome,
                Descricao = movieDetails.Descricao,
                Preco = movieDetails.Preco,
                DataInicial = movieDetails.DataInicial,
                DataFinal = movieDetails.DataFinal,
                ImagemURL = movieDetails.ImagemURL,
                Categoria = movieDetails.Categoria,
                Cinema = movieDetails.CinemaId,
                Diretor = movieDetails.DiretorId,
                Atores = movieDetails.Atores_Filmes.Select(n => n.AtorId).ToList(),
            };

            var movieDropdownsData = await _service.GetMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Nome");
            ViewBag.Diretores = new SelectList(movieDropdownsData.Diretores, "Id", "Nome");
            ViewBag.Atores = new SelectList(movieDropdownsData.Atores, "Id", "Nome");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateMovie movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Nome");
                ViewBag.Diretores = new SelectList(movieDropdownsData.Diretores, "Id", "Nome");
                ViewBag.Atores = new SelectList(movieDropdownsData.Atores, "Id", "Nome");

                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Pesquisar(string search)
        {
            var allMovies = await _service.ObterTodos(n => n.Cinema);

            if (!string.IsNullOrEmpty(search))
            {
                var filteredResult = allMovies.Where(n => n.Nome.ToLower().Contains(search.ToLower()) || n.Descricao.ToLower().Contains(search.ToLower())).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allMovies);
        }
    }
}
