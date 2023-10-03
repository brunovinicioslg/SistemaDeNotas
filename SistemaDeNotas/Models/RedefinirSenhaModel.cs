using System.ComponentModel.DataAnnotations;

namespace SistemaDeNotas.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Email")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }
    }
}

