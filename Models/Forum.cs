using System.ComponentModel.DataAnnotations;

namespace Dona.Models
{
    public class Forum
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int UsuariaId { get; set; }
    }
}