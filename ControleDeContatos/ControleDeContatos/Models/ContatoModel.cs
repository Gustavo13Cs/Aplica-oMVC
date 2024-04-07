using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato")] //colocando como obrigatorio
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage ="O E-mail informado não é valido!")]
        public string Email { get; set; }
        [Required (ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage ="O Celular informado não é valido!")]
        public string Celular { get; set; }
        public int? UsuarioID { get; set; }
        public UsuarioModel Usuario { get; set; }

    }
}
