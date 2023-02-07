﻿using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class FilmesController : Controller
    {
        private readonly AppDbContext _context;

        public FilmesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var filmes = await _context.Filmes.Include(f => f.Cinema).OrderBy(f => f.Nome).ToListAsync();
            return View(filmes);
        }
    }
}