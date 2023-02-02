using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        
        public string Nome { get; set; }
        public string LogoURL { get; set; }
        public string Descricao { get; set; }

        //Relacionamentos
        public List<Filme> Filmes { get; set; }
    }
}
