using Dona.Data;
using Dona.Helpers;
using Dona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        public ActionResult<UsuariaDto> CriarUsuaria(UsuariaDto usuariaDto)
        {
            if (string.IsNullOrWhiteSpace(usuariaDto.Senha))
                throw new AppException("Senha é obrigatória");

            if (_dBContext.Usuarias.Any(x => x.Email == usuariaDto.Email))
                throw new AppException("Email \"" + usuariaDto.Email + "\" já está sendo usado.");

            byte[] senhaHash, senhaSalt;
            CriarHashSenha(usuariaDto.Senha, out senhaHash, out senhaSalt);

            var usuaria = new Usuaria()
            {
                Nome = usuariaDto.Nome,
                Email = usuariaDto.Email,
                Senha = usuariaDto.Senha,
                Telefone = usuariaDto.Telefone,
                Uf = usuariaDto.Uf,
                Profissao = usuariaDto.Profissao,
                SenhaHash = senhaHash,
                SenhaSalt = senhaSalt
            };

            usuariaDto.Senha = senhaHash.ToString();

            _dBContext.Usuarias.Add(usuaria);
            _dBContext.SaveChanges();

            return usuariaDto;
        }

        public void DeletarUsuaria(int id)
        {
            var usuaria = ObterUsuariaPorId(id);
            _dBContext.Usuarias.Remove(usuaria.Value);
            _dBContext.SaveChangesAsync();
        }

        public ActionResult<Usuaria> ObterUsuariaPorId(int id)
        {
            return _dBContext.Usuarias.Find(id);
        }

        public ActionResult<List<Usuaria>> ListarUsuarias()
        {
            List<Usuaria> usuarias = _dBContext.Usuarias.ToList();
            return usuarias;
        }

        public ActionResult<UsuariaDto> AtualizarUsuaria(int id, UsuariaDto usuariaDto)
        {
            var user = _dBContext.Usuarias.Find(id);

            if (user == null)
                throw new AppException("Usuário não encontrado");

            if (usuariaDto.Email != user.Email)
            {
                if (_dBContext.Usuarias.Any(x => x.Email == usuariaDto.Email))
                    throw new AppException("Email " + usuariaDto.Email + " já está sendo usado.");
            }

            user.Id = id;
            user.Nome = usuariaDto.Nome;
            user.Email = usuariaDto.Email;
            user.Telefone = usuariaDto.Telefone;
            user.Uf = usuariaDto.Uf;
            user.Profissao = usuariaDto.Profissao;

            _dBContext.Usuarias.Update(user);
            _dBContext.SaveChanges();

            return usuariaDto;
        }

        public Usuaria Autenticar(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
                return null;

            var user = _dBContext.Usuarias.SingleOrDefault(x => x.Email == email);

            if (user == null)
                return null;

            if (!VerificarHashSenha(senha, user.SenhaHash, user.SenhaSalt))
                return null;

            return user;
        }

        private static void CriarHashSenha(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            if (senha == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                senhaSalt = hmac.Key;
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }
        }

        private static bool VerificarHashSenha(string senha, byte[] storedHash, byte[] storedSalt)
        {
            if (senha == null) throw new ArgumentNullException("senha");
            if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException("O valor não pode ser vazio ou conter espaço em branco.", "senha");
            if (storedHash.Length != 64) throw new ArgumentException("Tamanho inválido (64 bytes expected).", "senhaHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Tamanho inválido (128 bytes expected).", "senhaHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

    }
}