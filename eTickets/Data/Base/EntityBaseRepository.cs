using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Apagar(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Atualizar(int id, T NewEntity)
        {
            _context.Update(NewEntity);
            await _context.SaveChangesAsync();
            return NewEntity;
        }

        public async Task<T> ObterPorId(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> ObterTodos() => await _context.Set<T>().ToListAsync();
    }
}
