using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Ator : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome inválido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Biografia { get; set; }
        [Display(Name = "Foto")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string FotoPerfilURL { get; set; }

        //Relacionamentos
        public List<Ator_Filme>? Atores_Filmes { get; set; }
    }
}
