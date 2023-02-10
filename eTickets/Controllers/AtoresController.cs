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
            if(!ModelState.IsValid)
            {
                return View(ator);
            }

            await _service.Adicionar(ator);
            return RedirectToAction(nameof(Index));
        }
    }
}
