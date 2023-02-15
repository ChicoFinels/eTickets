using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;

        public CinemasController(ICinemaService service)
        {
            _service= service;
        }

        public async Task<IActionResult> Index()
        {
            var cinemas = await _service.ObterTodos();
            return View(cinemas);
        }

        //Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nome, LogoURL, Descricao")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.Adicionar(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _service.ObterPorId(id);
            if (cinema == null)
                return View("NotFound");
            return View(cinema);
        }

        //Get: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _service.ObterPorId(id);
            if (cinema == null)
                return View("NotFound");
            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nome, LogoURL, Descricao")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.Atualizar(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _service.ObterPorId(id);
            if (cinema == null)
                return View("NotFound");
            return View(cinema);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinema = await _service.ObterPorId(id);
            if (cinema == null)
                return View("NotFound");
            await _service.Apagar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
