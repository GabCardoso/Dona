using Dona.Data;
using Dona.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dona.Services
{
    public class UsuariaService : IUsuariaService
    {
        private readonly SQLiteDBContext _dBContext;

        public UsuariaService(SQLiteDBContext context)
        {
            _dBContext = context;
        }

        public Task<Usuaria> AddUsuaria(Usuaria usuaria)
        {
            throw new NotImplementedException();
        }

        public Task<Usuaria> DeleteUsuaria(int id, Usuaria usuaria)
        {
            throw new NotImplementedException();
        }

        public Task<Usuaria> GetUsuariaById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Usuaria>> ListUsuarias()
        {
            //List<Usuaria> usuarias = await _dBContext.Usuarias.ToListAsync();
            return null;
        }

        public Task UpdateUsuaria(int id, Usuaria usuaria)
        {
            throw new NotImplementedException();
        }
    }
}