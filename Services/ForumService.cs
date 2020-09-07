using Dona.Data;
using Dona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Dona.Services
{
    public class ForumService : IForumService
    {
        private readonly SQLiteDBContext _dBContext;

        public ForumService(SQLiteDBContext context)
        {
            _dBContext = context;
        }

        public ActionResult<Forum> AddForum(ForumDto forumDto)
        {
            var forum = new Forum()
            {
                Nome = forumDto.Nome,
                Descricao = forumDto.Descricao,
                UsuariaId = forumDto.UsuariaId
            };

            _dBContext.Foruns.Add(forum);
            _dBContext.SaveChangesAsync();

            return forum;
        }

        public void DeleteForum(int id)
        {
            var forum = GetForumById(id);
            _dBContext.Foruns.Remove(forum.Value);
            _dBContext.SaveChangesAsync();
        }

        public ActionResult<Forum> GetForumById(int id)
        {
            return _dBContext.Foruns.Find(id);

        }

        public ActionResult<List<Forum>> ListForuns()
        {
            List<Forum> foruns = _dBContext.Foruns.ToList();
            return foruns;
        }

        public ActionResult<List<Forum>> ListForunsByUsuariaId(int usuariaId)
        {
            List<Forum> foruns = _dBContext.Foruns.Where(f => f.UsuariaId == usuariaId).ToList();
            return foruns;
        }

        public ActionResult<Forum> UpdateForum(int id, ForumDto forumDto)
        {
            var forum = new Forum()
            {
                Id = id,
                Nome = forumDto.Nome,
                Descricao = forumDto.Descricao,
                UsuariaId = forumDto.UsuariaId
            };

            _dBContext.Entry(forum).State = EntityState.Modified;
            _dBContext.SaveChangesAsync();

            return forum;
        }
    }
}