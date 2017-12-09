using System;
using System.Collections.Generic;
using System.Linq;
using PCComponentes.Models;
using SQLite;
using System.Threading.Tasks;

namespace PCComponentes
{
	public class UsuariosRepository
	{
		public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

		public UsuariosRepository(string dbPath)
		{
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Usuario>().Wait();
		}

		public async Task<List<Usuario>> GetAllUsuariosAsync()
		{
            List<Usuario> lista = new List<Usuario>();

            try
            {
                lista = await conn.Table<Usuario>().ToListAsync();

            }
            catch (Exception ex)
            {
                StatusMessage = String.Format("Failed to retireve data. {0}", ex.Message);
                lista = new List<Usuario>();
            }

            return lista;
        }
	}
}