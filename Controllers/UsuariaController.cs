using Dona.Models;
using Dona.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Dona.Helpers;

namespace Dona.Controllers
{
    [ApiController]
    [Route("usuaria")]
    public class UsuariaController : ControllerBase
    {
        private readonly IUsuariaService _usuariaService;
        private readonly AppSettings _appSettings;

        public UsuariaController(IUsuariaService usuariaService, IOptions<AppSettings> appSettings)
        {
            _usuariaService = usuariaService;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Criar Usuária
        /// </summary>
        /// <remarks>Criar usuária</remarks>
        [HttpPost("criar-usuaria")]
        public ActionResult<UsuariaDto> CriarUsuaria([FromBody] UsuariaDto usuaria)
        {
            return _usuariaService.CriarUsuaria(usuaria);
        }

        /// <summary>
        /// Atualizar Usuária
        /// </summary>
        /// <param name="usuariaId">Id do usuária.</param>
        /// <remarks>Atualizar usuária</remarks>
        [HttpPost("atualizar-usuaria/{usuariaId}")]
        public ActionResult<UsuariaDto> AtualizarUsuaria([FromRoute] int usuariaId, [FromBody] UsuariaDto usuaria)
        {
            return _usuariaService.AtualizarUsuaria(usuariaId, usuaria);
        }

        /// <summary>
        /// Obter Usuária
        /// </summary>
        /// <param name="usuariaId">Id do usuária.</param>
        /// <remarks>Obter usuária</remarks>
        [HttpGet("obter-usuaria-por-id/{usuariaId}")]
        public ActionResult<Usuaria> ObterUsuariaPorId([FromRoute] int usuariaId)
        {
            return _usuariaService.ObterUsuariaPorId(usuariaId);
        }

        /// <summary>
        /// Obter Usuárias
        /// </summary>
        /// <remarks>Obter usuárias</remarks>
        [HttpGet("listar-usuarias")]
        public ActionResult<List<Usuaria>> ListarUsuarias()
        {
            return _usuariaService.ListarUsuarias();
        }

        /// <summary>
        /// Deletar Usuária
        /// </summary>
        /// <param name="usuariaId">Id do usuária.</param>
        /// <remarks>Deletar usuária</remarks>
        [HttpDelete("deletar-usuaria/{usuariaId}")]
        public ActionResult DeletarUsuaria([FromRoute] int usuariaId)
        {
            _usuariaService.DeletarUsuaria(usuariaId);
            return NoContent();
        }

        /// <summary>
        /// Autenticar
        /// </summary>
        /// <remarks>Autenticar</remarks>
        [AllowAnonymous]
        [HttpPost("authenticar")]
        public IActionResult Authenticar([FromBody]UsuariaDto usuariaDto)
        {
            var user = _usuariaService.Autenticar(usuariaDto.Email, usuariaDto.Senha);

            if (user == null)
                return BadRequest(new { message = "Nome de usuário ou senha incorreta" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                Token = tokenString
            });
        }
    }
}