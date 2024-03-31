using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {

            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuario = _usuarioRepositorio.BuscarTodos();
            return View(usuario);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastro com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);

            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos codastrar seu usuario, Tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }



        }
    }
}
