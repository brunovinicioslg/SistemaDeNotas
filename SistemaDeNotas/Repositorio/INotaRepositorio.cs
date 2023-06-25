using SistemaDeNotas.Enums;
using SistemaDeNotas.Models;

namespace SistemaDeNotas.Repositorio
{
    public interface INotaRepositorio
    {
        NotaModel ListarPorId(int id);
        NotaModel ListarPorMateria(string mat);
        List<NotaModel> BuscarTodos(int usuarioId);
        List<NotaModel> BuscarTodosAdm();
        NotaModel Adicionar(NotaModel nota2);
        NotaModel Atualizar(NotaModel nota);

        bool Apagar(int id);
    }
}
