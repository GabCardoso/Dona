using Dona.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dona.Services
{
    public interface IComentarioService
    {
        ActionResult<List<Comentario>> ListComentariosByForumId(int forumId);
        ActionResult<Comentario> AddComentario(ComentarioDto comentarioDto);
        ActionResult<Comentario> UpdateComentario(int id, ComentarioDto comentarioDto);
        void DeleteComentario(int id);
    }
}