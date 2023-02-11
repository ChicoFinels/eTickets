using eTickets.Models;
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

        public async Task Adicionar(Ator ator)
        {
            await _context.Atores.AddAsync(ator);
            await _context.SaveChangesAsync();
        }

        public async Task Apagar(int id)
        {
            var ator = await _context.Atores.FindAsync(id);
            _context.Atores.Remove(ator);
            await _context.SaveChangesAsync();
        }

        public async Task<Ator> Atualizar(int id, Ator NovoAtor)
        {
            _context.Update(NovoAtor);
            await _context.SaveChangesAsync();
            return NovoAtor;
        }

        public async Task<Ator> ObterPorId(int id)
        {
            var resultado = await _context.Atores.FindAsync(id);
            return resultado;
        }

        public async Task<IEnumerable<Ator>> ObterTodos()
        {
            var resultado = await _context.Atores.ToListAsync();
            return resultado;
        }
    }
}
