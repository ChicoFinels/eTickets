﻿using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
