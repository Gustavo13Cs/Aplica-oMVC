using ControleDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string  Nome { get; set; }
        [Required(ErrorMessage = "Digite o Login do usuario")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o email do usuario")]
        [EmailAddress(ErrorMessage = "O E-mail informado não é valido!")]
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuario")]
        public string Senha { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public DateTime? DataDeAtualizacao { get; set; } 
    }
}
