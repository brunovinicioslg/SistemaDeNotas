using SistemaDeNotas.Enums;
using SistemaDeNotas.Models;

namespace SistemaDeNotas.Repositorio
{
    public interface IAvisosRepositorio
    {

       AvisosModel ListarPorId(int id);
        List<AvisosModel> BuscarTodosAdm();
        AvisosModel Adicionar(AvisosModel aviso);
        AvisosModel Atualizar(AvisosModel aviso);

        bool Apagar(int id);

    }
}
