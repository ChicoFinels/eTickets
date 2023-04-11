using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class CreateMovie
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Descricao { get; set; }

        [Display(Name = "Preço (€)")]
        [Required(ErrorMessage = "Preço é obrigatório")]
        public double Preco { get; set; }

        [Display(Name = "URL da Capa")]
        [Required(ErrorMessage = "URL da capa do filme é obrigatório")]
        public string ImagemURL { get; set; }

        [Display(Name = "Data Inicial")]
        [Required(ErrorMessage = "Data inicial obrigatória")]
        public DateTime DataInicial { get; set; }

        [Display(Name = "Data Final")]
        [Required(ErrorMessage = "Data final obrigatória")]
        public DateTime DataFinal { get; set; }

        [Display(Name = "Seleciona a categoria")]
        [Required(ErrorMessage = "Categoria é obrigatória")]
        public Categoria Categoria { get; set; }

        //Relationships
        [Display(Name = "Seleciona os atores")]
        [Required(ErrorMessage = "Atores são obrigatórios")]
        public List<int> Atores { get; set; }

        [Display(Name = "Seleciona o cinema")]
        [Required(ErrorMessage = "Cinema é obrigatório")]
        public int Cinema { get; set; }

        [Display(Name = "Seleciona o diretor")]
        [Required(ErrorMessage = "Diretor é obrigatório")]
        public int Diretor { get; set; }
    }
}
