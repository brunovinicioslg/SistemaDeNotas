using SistemaDeNotas.Models;

namespace SistemaDeNotas.Repositorio
{
    public interface INotaRepositorio
    {
        NotaModel ListarPorId(int id);
        NotaModel ListarPorMateria(string mat);
        List<NotaModel> BuscarTodos();
        NotaModel Adicionar(NotaModel nota);
        NotaModel Atualizar(NotaModel nota);

        bool Apagar(int id);
    }
}
