using Dona.Models;
using Dona.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dona.Controllers
{
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;
        private readonly IComentarioService _comentarioService;

        public ForumController(IForumService forumService,
            IComentarioService comentarioService)
        {
            _forumService = forumService;
            _comentarioService = comentarioService;
        }

        /// <summary>
        /// Criar Fórum
        /// </summary>
        /// <remarks>Criar forúm</remarks>
        [HttpPost("criar-forum")]
        public ActionResult<Forum> CriarForum([FromBody] ForumDto forum)
        {
            return _forumService.AddForum(forum);
        }

        /// <summary>
        /// Atualizar Fórum
        /// </summary>
        /// <param name="forumId">Id do forúm.</param>
        /// <remarks>Atualizar forúm</remarks>
        [HttpPost("atualizar-forum/{forumId}")]
        public ActionResult<Forum> AtualizarForum([FromRoute] int forumId, [FromBody] ForumDto forum)
        {
            return _forumService.UpdateForum(forumId, forum);
        }

        /// <summary>
        /// Obter Fórum
        /// </summary>
        /// <param name="forumId">Id do forúm.</param>
        /// <remarks>Obter forúm</remarks>
        [HttpGet("obter-forum/{forumId}")]
        public ActionResult<Forum> ObterForum([FromRoute] int forumId)
        {
            return _forumService.GetForumById(forumId);
        }

        /// <summary>
        /// Obter Fóruns
        /// </summary>
        /// <remarks>Obter forúns</remarks>
        [HttpGet("obter-foruns")]
        public ActionResult<List<Forum>> ObterForuns()
        {
            return _forumService.ListForuns();
        }

        /// <summary>
        /// Obter Fóruns
        /// </summary>
        /// <param name="usuariaId">Id do comentário.</param>
        /// <remarks>Obter forúns</remarks>
        [HttpGet("obter-foruns/{usuariaId}")]
        public ActionResult<List<Forum>> ObterForuns(int usuariaId)
        {
            return _forumService.ListForunsByUsuariaId(usuariaId);
        }

        /// <summary>
        /// Deletar Fórum
        /// </summary>
        /// <param name="forumId">Id do forúm.</param>
        /// <remarks>Deletar forúm</remarks>
        [HttpDelete("deletar-forum/{forumId}")]
        public ActionResult DeletarForum([FromRoute] int forumId)
        {
            _forumService.DeleteForum(forumId);
            return NoContent();
        }

        /// <summary>
        /// Criar Comentário
        /// </summary>
        /// <remarks>Criar Comentário</remarks>
        [HttpPost("criar-comentario")]
        public ActionResult<Comentario> CriarComentario([FromBody] ComentarioDto comentario)
        {
            return _comentarioService.AddComentario(comentario);
        }

        /// <summary>
        /// Obter Comentários
        /// </summary>
        /// <param name="forumId">Id do comentário.</param>
        /// <remarks>Obter comentários</remarks>
        [HttpGet("obter-comentarios/{forumId}")]
        public ActionResult<List<Comentario>> ObterComentarios(int forumId)
        {
            return _comentarioService.ListComentariosByForumId(forumId);
        }

        /// <summary>
        /// Deletar Comentário
        /// </summary>
        /// <param name="comentarioId">Id do comentário.</param>
        /// <remarks>Deletar comentario</remarks>
        [HttpDelete("deletar-comentario/{comentarioId}")]
        public ActionResult DeletarComentario([FromRoute] int comentarioId)
        {
            _comentarioService.DeleteComentario(comentarioId);
            return NoContent();
        }
    }
}