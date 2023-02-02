﻿using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Ator
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Biografia { get; set; }
        public string FotoPerfilURL { get; set;}
    }
}
