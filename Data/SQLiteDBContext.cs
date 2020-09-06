using Dona.Models;
using Microsoft.EntityFrameworkCore;

namespace Dona.Data
{
    public class SQLiteDBContext: DbContext
    {
        public DbSet<Usuaria> Usuarias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=UsuariasSqlite.db");
    }
}