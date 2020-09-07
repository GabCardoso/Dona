using System.ComponentModel.DataAnnotations;

namespace Dona.Models
{
    public class Usuaria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(128)]
        public string Email { get; set; }
        [Required]
        [MaxLength(128)]
        public string Senha { get; set; }
        [MaxLength(128)]
        public string Telefone { get; set; }
        [Required]
        [MaxLength(2)]
        public string Uf { get; set; }
        [Required]
        [MaxLength(128)]
        public string Profissao { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
    }
}