using SistemaDeNotas.Enums;
using SistemaDeNotas.Models;

namespace SistemaDeNotas.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorlogin(string usuario);
        UsuarioModel BuscarPorEmailELogin(string email, string login);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel ListarPorId(int id);
        UsuarioModel ListarPorUsuario(string usuario);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        UsuarioModel AtualizarSenha(UsuarioModel usuario);

        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);

       UsuarioModel BuscarNome(int id);

        bool Apagar(int id);
    }
}
