using System.ComponentModel.DataAnnotations;

namespace SistemaDeNotas.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Usuario")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }
    }
}
