using Dona.Data;
using Dona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Dona.Services
{
    public class UsuariaService : IUsuariaService
    {
        private readonly SQLiteDBContext _dBContext;

        public UsuariaService(SQLiteDBContext context)
        {
            _dBContext = context;
        }

        public ActionResult<Usuaria> AddUsuaria(UsuariaDto usuariaDto)
        {
            var usuaria = new Usuaria()
            {
                Nome = usuariaDto.Nome,
                Email = usuariaDto.Email,
                Senha = usuariaDto.Senha,
                Telefone = usuariaDto.Telefone,
                Uf = usuariaDto.Uf,
                Profissao = usuariaDto.Profissao
            };

            _dBContext.Usuarias.Add(usuaria);
            _dBContext.SaveChangesAsync();

            return usuaria;
        }

        public void DeleteUsuaria(int id)
        {
            var usuaria = GetUsuariaById(id);
            _dBContext.Usuarias.Remove(usuaria.Value);
            _dBContext.SaveChangesAsync();
        }

        public ActionResult<Usuaria> GetUsuariaById(int id)
        {
            return _dBContext.Usuarias.Find(id);
        }

        public ActionResult<List<Usuaria>> ListUsuarias()
        {
            List<Usuaria> usuarias = _dBContext.Usuarias.ToList();
            return usuarias;
        }

        public ActionResult<Usuaria> UpdateUsuaria(int id, UsuariaDto usuariaDto)
        {
            var usuaria = new Usuaria()
            {
                Id = id,
                Nome = usuariaDto.Nome,
                Email = usuariaDto.Email,
                Senha = usuariaDto.Senha,
                Telefone = usuariaDto.Telefone,
                Uf = usuariaDto.Uf,
                Profissao = usuariaDto.Profissao
            };

            _dBContext.Entry(usuaria).State = EntityState.Modified;
            _dBContext.SaveChangesAsync();

            return usuaria;
        }
    }
}