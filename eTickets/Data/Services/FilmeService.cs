using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class FilmeService : EntityBaseRepository<Filme>, IFilmeService
    {
        private readonly AppDbContext _context;
        public FilmeService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Filme> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Filmes
                .Include(c => c.Cinema)
                .Include(p => p.Diretor)
                .Include(am => am.Atores_Filmes).ThenInclude(a => a.Ator)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }
    }
}
