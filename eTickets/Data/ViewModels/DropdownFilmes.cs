using eTickets.Models;

namespace eTickets.Data.ViewModels
{
    public class DropdownFilmes
    {
        public List<Diretor> Diretores { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Ator> Atores { get; set; }
    }
}
