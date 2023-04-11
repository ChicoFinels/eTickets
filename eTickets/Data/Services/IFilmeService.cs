using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IFilmeService : IEntityBaseRepository<Filme>
    {
        Task<Filme> GetMovieByIdAsync(int id);
    }
}
