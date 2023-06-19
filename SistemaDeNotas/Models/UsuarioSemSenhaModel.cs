using SistemaDeNotas.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeNotas.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome")]
        public string Nome { get; set; }
        public string? Email { get; set;}
        [Required(ErrorMessage = "Digite a Senha")]
        public string Turma { get; set;}
        [Required(ErrorMessage = "Informe o Perfil")]
        public PerfilEnum? Perfil { get; set; }

    }
}
