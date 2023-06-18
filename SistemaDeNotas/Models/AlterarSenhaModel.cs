using System.ComponentModel.DataAnnotations;

namespace SistemaDeNotas.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a senha atual")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Digite a nova senha")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessage ="Senha não confere, confira as senhas")]
        public string ConfirmarNovaSenha {get ; set; }  

    }
}
