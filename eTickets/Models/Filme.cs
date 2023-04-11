using eTickets.Data.Base;
using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Filme : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Preço")]
        public double Preco { get; set; }
        [Display(Name = "Capa")]
        public string ImagemURL { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public Categoria Categoria { get; set; }

        //Relacionamentos
        public List<Ator_Filme> Atores_Filmes { get; set; }

        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        public int DiretorId { get; set; }
        [ForeignKey("DiretorId")]
        public Diretor Diretor { get; set; }
    }
}
