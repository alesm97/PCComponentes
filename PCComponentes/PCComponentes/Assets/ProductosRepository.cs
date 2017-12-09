using System;
using System.Collections.Generic;
using System.Linq;
using PCComponentes.Models;
using SQLite;
using System.Threading.Tasks;

namespace PCComponentes
{
	public class ProductosRepository
	{
		public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public ProductosRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Producto>().Wait();
        }

		public async Task<List<Producto>> GetAllProductosAsync()
		{
            List<Producto> lista = new List<Producto>();

            try
            {
                lista = await conn.Table<Producto>().ToListAsync();

            }
            catch (Exception ex)
            {

            }

            return lista;
        }
	}
}