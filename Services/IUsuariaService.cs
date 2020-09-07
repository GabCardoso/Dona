using Dona.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dona.Services
{
    public interface IUsuariaService
    {
        ActionResult<List<Usuaria>> ListarUsuarias();
        ActionResult<UsuariaDto> CriarUsuaria(UsuariaDto usuaria);
        ActionResult<Usuaria> ObterUsuariaPorId(int id);
        ActionResult<UsuariaDto> AtualizarUsuaria(int id, UsuariaDto usuaria);
        void DeletarUsuaria(int id);
        public Usuaria Autenticar(string email, string senha);
    }
}