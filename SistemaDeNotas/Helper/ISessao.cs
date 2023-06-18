using SistemaDeNotas.Models;

namespace SistemaDeNotas.Helper
{
    public interface ISessao
    {
        void CriarSessaoDousuario(UsuarioModel usuario);
        void RemoverSessaoDousuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
