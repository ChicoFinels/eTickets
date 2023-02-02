namespace eTickets.Models
{
    public class Ator_Filme
    {
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }

        public int AtorId { get; set; }
        public Ator Ator { get; set; }
    }
}
