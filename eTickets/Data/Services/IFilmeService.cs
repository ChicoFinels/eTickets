using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IFilmeService : IEntityBaseRepository<Filme>
    {
        Task<Filme> GetMovieByIdAsync(int id);
        Task<DropdownFilmes> GetMovieDropdownsValues();
        Task AdicionarFilme(CreateMovie data);
        Task UpdateMovieAsync(CreateMovie data);
    }
}
