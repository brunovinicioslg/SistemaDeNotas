using System.ComponentModel.DataAnnotations;

namespace SistemaDeNotas.Models
{
    public class AvisosModel
    {
       public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Titulo")]
        public string AvisoTitulo { get; set; }
        [Required(ErrorMessage = "Digite o Aviso")]
        public string AvisoCorpo { get; set; }


    }
}
