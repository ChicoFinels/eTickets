using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Diretor
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Biografia { get; set; }
        public string FotoPerfilURL { get; set; }
    }
}
