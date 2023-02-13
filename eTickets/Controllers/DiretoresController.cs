using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class DiretoresController : Controller
    {
        private readonly IDiretorService _service;

        public DiretoresController(IDiretorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var diretores = await _service.ObterTodos();
            return View(diretores);
        }

        //Get: Diretores/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nome, FotoPerfilURL, Biografia")] Diretor diretor)
        {
            if (!ModelState.IsValid)
            {
                return View(diretor);
            }
            await _service.Adicionar(diretor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Diretores/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var diretor = await _service.ObterPorId(id);
            if (diretor == null)
                return View("NotFound");
            return View(diretor);
        }

        //Get: Diretores/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var diretor = await _service.ObterPorId(id);
            if (diretor == null)
                return View("NotFound");
            return View(diretor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nome, FotoPerfilURL, Biografia")] Diretor diretor)
        {
            if (!ModelState.IsValid)
            {
                return View(diretor);
            }
            await _service.Atualizar(id, diretor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Diretores/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var diretor = await _service.ObterPorId(id);
            if (diretor == null)
                return View("NotFound");
            return View(diretor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diretor = await _service.ObterPorId(id);
            if (diretor == null)
                return View("NotFound");
            await _service.Apagar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
