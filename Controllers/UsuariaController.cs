using Dona.Models;
using Dona.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dona.Controllers
{
    [ApiController]
    [Route("usuaria")]
    public class UsuariaController
    {
        private readonly IUsuariaService _usuariaService;

        public UsuariaController(IUsuariaService usuariaService)
        {
            _usuariaService = usuariaService;
        }

        /// <summary>
        /// Criar Usuária
        /// </summary>
        /// <remarks>Criar usuária</remarks>
        [HttpPost("criar-usuaria")]
        public Task<Usuaria> CriarUsuaria([FromBody] Usuaria usuaria)
        {
            return _usuariaService.AddUsuaria(usuaria);
        }

        /// <summary>
        /// Atualizar Usuária
        /// </summary>
        /// <param name="usuariaId">Id do usuária.</param>
        /// <remarks>Atualizar usuária</remarks>
        [HttpPost("atualizar-usuaria/{usuariaId}")]
        public Task AtualizarUsuaria([FromRoute] int usuariaId, [FromBody] Usuaria usuaria)
        {
            return _usuariaService.UpdateUsuaria(usuariaId, usuaria);
        }

        /// <summary>
        /// Obter Usuária
        /// </summary>
        /// <param name="usuariaId">Id do usuária.</param>
        /// <remarks>Obter usuária</remarks>
        [HttpGet("obter-usuaria/{usuariaId}")]
        public Task<Usuaria> ObterUsuaria([FromRoute] int usuariaId)
        {
            return _usuariaService.GetUsuariaById(usuariaId);
        }

        /// <summary>
        /// Obter Usuárias
        /// </summary>
        /// <remarks>Obter usuárias</remarks>
        [HttpGet("obter-usuarias")]
        public async Task<ActionResult<IEnumerable<Usuaria>>> ObterUsuarias()
        {
            return await _usuariaService.ListUsuarias();
        }

        /// <summary>
        /// Deletar Usuária
        /// </summary>
        /// <param name="usuariaId">Id do usuária.</param>
        /// <remarks>Deletar usuária</remarks>
        [HttpDelete("deletar-usuaria/{usuariaId}")]
        public Task<Usuaria> DeletarUsuaria([FromRoute] int usuariaId, [FromBody] Usuaria usuaria)
        {
            return _usuariaService.DeleteUsuaria(usuariaId, usuaria);
        }

        /// <summary>
        /// Autenticar
        /// </summary>
        /// <remarks>Autenticar</remarks>
        [HttpPost("autenticar")]
        public void Autenticar()
        {

        }
    }
}