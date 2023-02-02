using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string ImagemURL { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set;}
        public Categoria Categoria { get; set; }
    }
}
