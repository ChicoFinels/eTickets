using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class DiretorService : EntityBaseRepository<Diretor>, IDiretorService
    {
        public DiretorService(AppDbContext context) : base(context)
        {
        }
    }
}
