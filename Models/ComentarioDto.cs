using System;

namespace Dona.Models
{
    public class ComentarioDto
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int ForumId { get; set; }
        public int UsuariaId { get; set; }
    }
}