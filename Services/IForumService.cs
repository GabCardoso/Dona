using Dona.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dona.Services
{
    public interface IForumService
    {
        ActionResult<List<Forum>> ListForuns();
        ActionResult<List<Forum>> ListForunsByUsuariaId(int usuariaId);
        ActionResult<Forum> AddForum(ForumDto forum);
        ActionResult<Forum> GetForumById(int id);
        ActionResult<Forum> UpdateForum(int id, ForumDto forum);
        void DeleteForum(int id);
    }
}