using System;
using System.ComponentModel.DataAnnotations;

namespace Dona.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int ForumId { get; set; }
        [Required]
        public int UsuariaId { get; set; }
    }
}