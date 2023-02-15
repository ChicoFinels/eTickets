using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Nome inválido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Logo")]
        public string LogoURL { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        //Relacionamentos
        public List<Filme>? Filmes { get; set; }
    }
}
