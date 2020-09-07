using Dona.Data;
using Dona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Dona.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly SQLiteDBContext _dBContext;

        public ComentarioService(SQLiteDBContext context)
        {
            _dBContext = context;
        }

        public ActionResult<Comentario> AddComentario(ComentarioDto comentarioDto)
        {
            var comentario = new Comentario()
            {
                Descricao = comentarioDto.Descricao,
                ForumId = comentarioDto.ForumId,
                UsuariaId = comentarioDto.UsuariaId
            };

            _dBContext.Comentarios.Add(comentario);
            _dBContext.SaveChangesAsync();

            return comentario;
        }

        public void DeleteComentario(int id)
        {
            var comentario = GetComentarioById(id);
            _dBContext.Comentarios.Remove(comentario);
            _dBContext.SaveChangesAsync();
        }

        private Comentario GetComentarioById(int id)
        {
            return _dBContext.Comentarios.Find(id);

        }

        public ActionResult<List<Comentario>> ListComentariosByForumId(int forumId)
        {
            List<Comentario> comentarios = _dBContext.Comentarios.Where(f => f.ForumId == forumId).ToList();
            return comentarios;
        }

        public ActionResult<Comentario> UpdateComentario(int id, ComentarioDto comentarioDto)
        {
            var comentario = new Comentario()
            {
                Id = id,
                Descricao = comentarioDto.Descricao,
                ForumId = comentarioDto.ForumId,
                UsuariaId = comentarioDto.UsuariaId
            };

            _dBContext.Entry(comentario).State = EntityState.Modified;
            _dBContext.SaveChangesAsync();

            return comentario;
        }
    }
}