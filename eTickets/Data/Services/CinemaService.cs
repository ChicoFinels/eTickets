using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        public CinemaService(AppDbContext context) : base(context)
        {
        }
    }
}
