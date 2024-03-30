using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList(); //ta carregando tudo que ta no banco de dados
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            // gravar no banco de dados

            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges(); //e como se fosse uma confirmação
            return contato;
        }

       
    }
}
