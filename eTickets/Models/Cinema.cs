using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        [Display(Name = "Logo")]
        public string LogoURL { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        //Relacionamentos
        public List<Filme> Filmes { get; set; }
    }
}
