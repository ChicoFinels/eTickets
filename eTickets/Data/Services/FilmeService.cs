using eTickets.Data.Base;
using eTickets.Data.ViewModels;
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

        public async Task<DropdownFilmes> GetMovieDropdownsValues()
        {
            var response = new DropdownFilmes()
            {
                Atores = await _context.Atores.OrderBy(n => n.Nome).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Nome).ToListAsync(),
                Diretores = await _context.Diretores.OrderBy(n => n.Nome).ToListAsync()
            };

            return response;
        }

        public async Task AdicionarFilme(CreateMovie data)
        {
            var newMovie = new Filme()
            {
                Nome = data.Nome,
                Descricao = data.Descricao,
                Preco = data.Preco,
                ImagemURL = data.ImagemURL,
                CinemaId = data.Cinema,
                DataInicial = data.DataInicial,
                DataFinal = data.DataFinal,
                Categoria = data.Categoria,
                DiretorId = data.Diretor
            };
            await _context.Filmes.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.Atores)
            {
                var newActorMovie = new Ator_Filme()
                {
                    FilmeId = newMovie.Id,
                    AtorId = actorId
                };
                await _context.Atores_Filmes.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(CreateMovie data)
        {
            var dbMovie = await _context.Filmes.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Nome = data.Nome;
                dbMovie.Descricao = data.Descricao;
                dbMovie.Preco = data.Preco;
                dbMovie.ImagemURL = data.ImagemURL;
                dbMovie.CinemaId = data.Cinema;
                dbMovie.DataInicial = data.DataInicial;
                dbMovie.DataFinal = data.DataFinal;
                dbMovie.Categoria = data.Categoria;
                dbMovie.DiretorId = data.Diretor;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Atores_Filmes.Where(n => n.FilmeId == data.Id).ToList();
            _context.Atores_Filmes.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.Atores)
            {
                var newActorMovie = new Ator_Filme()
                {
                    FilmeId = data.Id,
                    AtorId = actorId
                };
                await _context.Atores_Filmes.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
