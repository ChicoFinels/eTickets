using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class AtoresController : Controller
    {
        private readonly IActorService _service;

        public AtoresController(IActorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var atores = await _service.ObterTodos();
            return View(atores);
        }

        //Get: Atores/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nome, FotoPerfilURL, Biografia")] Ator ator)
        {
            if (!ModelState.IsValid)
            {
                return View(ator);
            }
            await _service.Adicionar(ator);
            return RedirectToAction(nameof(Index));
        }

        //Get: Atores/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var ator = await _service.ObterPorId(id);
            if (ator == null)
                return View("NotFound");
            return View(ator);
        }

        //Get: Atores/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var ator = await _service.ObterPorId(id);
            if (ator == null)
                return View("NotFound");
            return View(ator);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nome, FotoPerfilURL, Biografia")] Ator ator)
        {
            if (!ModelState.IsValid)
            {
                return View(ator);
            }
            await _service.Atualizar(id, ator);
            return RedirectToAction(nameof(Index));
        }
    }
}
