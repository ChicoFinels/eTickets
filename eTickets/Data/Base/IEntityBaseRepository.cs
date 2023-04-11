using System.Linq.Expressions;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        //obter todos os objetos da tabela T
        Task<IEnumerable<T>> ObterTodos();
        //obter objeto pelo ID
        Task<T> ObterPorId(int id);
        //adicionar um objeto
        Task Adicionar(T entity);
        //alterar um objeto existente
        Task<T> Atualizar(int id, T NewEntity);
        //apagar objeto
        Task Apagar(int id);
        //obter todos os objetos da tabela T incluindo propriedades
        Task<IEnumerable<T>> ObterTodos(params Expression<Func<T, object>>[] includeProperties);
        //obter objeto pelo ID incluindo propriedades
        Task<T> ObterPorId(int id, params Expression<Func<T, object>>[] includeProperties);

    }
}
