using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorService
    {
        //obter todos os atores
        Task<IEnumerable<Ator>> ObterTodos();
        //obter ator pelo ID
        Task<Ator> ObterPorId(int id);
        //adicionar ator
        Task Adicionar(Ator ator);
        //alterar um ator existente
        Task<Ator> Atualizar(int id, Ator NovoAtor);
        //apagar ator
        Task Apagar(int id);
    }
}
