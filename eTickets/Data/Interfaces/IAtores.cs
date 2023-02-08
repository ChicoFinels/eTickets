using eTickets.Models;

namespace eTickets.Data.Interfaces
{
    public interface IAtores
    {
        //obter todos os atores
        IEnumerable<Ator> ObterTodos();
        //obter ator pelo ID
        Ator ObterPorId(int id);
        //adicionar ator
        void Adicionar(Ator ator);
        //alterar um ator existente
        Ator Atualizar(int id, Ator NovoAtor);
        //apagar ator
        void Apagar(int id);
    }
}
