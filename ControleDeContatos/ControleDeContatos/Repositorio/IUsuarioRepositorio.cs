using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel ListarPorID(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);
    }
}
