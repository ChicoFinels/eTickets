using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class RegistarVM
    {
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Nome completo é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Deve conter pelo menos 8 caracteres", MinimumLength = 8)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        [Display(Name = "Confirmar password")]
        [Required(ErrorMessage = "Confirmar password é obrigatório")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords não é compatível")]
        public string ConfirmarPassword { get; set; }
    }
}
