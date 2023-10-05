using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_dev_backend_2023.Models
{
    [Table("Usuários")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public Perfil Perfil { get; set; }

    }

    public enum Perfil
    {
        Admin,
        User
    }
}
