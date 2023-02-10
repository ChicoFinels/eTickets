using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorService
    {
        //obter todos os atores
        Task<IEnumerable<Ator>> ObterTodos();
        //obter ator pelo ID
        Ator ObterPorId(int id);
        //adicionar ator
        Task Adicionar(Ator ator);
        //alterar um ator existente
        Ator Atualizar(int id, Ator NovoAtor);
        //apagar ator
        void Apagar(int id);
    }
}
