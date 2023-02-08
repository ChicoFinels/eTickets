using eTickets.Data;
using eTickets.Data.Services;
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
    }
}
