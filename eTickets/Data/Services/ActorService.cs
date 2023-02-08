﻿using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;

        public ActorService(AppDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Ator ator)
        {
            throw new NotImplementedException();
        }

        public void Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Ator Atualizar(int id, Ator NovoAtor)
        {
            throw new NotImplementedException();
        }

        public Ator ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ator>> ObterTodos()
        {
            var resultado= await _context.Atores.ToListAsync();
            return resultado;
        }
    }
}
