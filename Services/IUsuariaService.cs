using Dona.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dona.Services
{
    public interface IUsuariaService
    {
        ActionResult<List<Usuaria>> ListUsuarias();
        ActionResult<Usuaria> AddUsuaria(UsuariaDto usuaria);
        ActionResult<Usuaria> GetUsuariaById(int id);
        ActionResult<Usuaria> UpdateUsuaria(int id, UsuariaDto usuaria);
        void DeleteUsuaria(int id);
    }
}