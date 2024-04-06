using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList(); //ta carregando tudo que ta no banco de dados
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            // gravar no banco de dados

            usuario.DataDeCadastro = DateTime.Now;
            usuario.SetSenhaHash(); //transforma senha criada pra cripotografia
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges(); //e como se fosse uma confirmação
            return usuario;
        }

        public UsuarioModel ListarPorID(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.id == id);
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorID(usuario.id);
            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do usuario!");

            usuario.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login= usuario.Login;
            usuarioDB.Perfil= usuario.Perfil;
            usuarioDB.DataDeAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();
            return usuarioDB;

        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorID(id);
            if (usuarioDB == null) throw new System.Exception("Houve um erro na deleção do usuario!");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;

        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
    }
}
