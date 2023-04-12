using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Utilizador : IdentityUser
    {
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }
    }
}
