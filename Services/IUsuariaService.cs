using Dona.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dona.Services
{
    public interface IUsuariaService
    {
        Task<List<Usuaria>> ListUsuarias();
        Task<Usuaria> AddUsuaria(Usuaria usuaria);
        Task<Usuaria> GetUsuariaById(int id);
        Task UpdateUsuaria(int id, Usuaria usuaria);
        Task<Usuaria> DeleteUsuaria(int id, Usuaria usuaria);
    }
}