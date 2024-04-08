using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos(int usuarioId);
        ContatoModel ListarPorID(int id);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
