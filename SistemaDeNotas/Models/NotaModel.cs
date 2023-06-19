using System.ComponentModel.DataAnnotations;

namespace SistemaDeNotas.Models
{
    public class NotaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome da Matéria")] 
        public string Materia { get; set; }
        public float? Nota1Bimestre { get; set; }
        public float? Nota2Bimestre { get; set; }
        public float? Nota3Bimestre { get; set; }
        public float? Nota4bimestre { get; set; }

        public int? UsuarioID { get; set; }

        public string? UsuarioNome { get; set; }



        public UsuarioModel? Usuario { get; set; }
        //public object? Enums { get; internal set; }
    }
}
