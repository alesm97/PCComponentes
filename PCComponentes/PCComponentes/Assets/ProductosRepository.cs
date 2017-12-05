using System;
using System.Collections.Generic;
using System.Linq;
using PCComponentes.Models;
using SQLite;
using System.Threading.Tasks;
using static PCComponentes.Models.Producto;

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

		public async Task AddNewProductoAsync(int id, string nombre, double precio, string tipo)
		{
			int result = 0;
			try
			{
				//basic validation to ensure a name was entered
				if (string.IsNullOrEmpty(nombre) && precio>=0)
					throw new Exception("Incorrect data.");

                result = await conn.InsertAsync(new Producto() { Nombre = nombre , Id = id , Precio = precio, Tipo = tipo});

				//StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, nombre);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add {0}. Error: {1}", nombre, ex.Message);
			}

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
                StatusMessage = String.Format("Failed to retireve data. {0}", ex.Message);
            }

            return lista;
        }
	}
}