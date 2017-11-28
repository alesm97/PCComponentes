using System;
using System.Collections.Generic;
using System.Linq;
using PCComponentes.Models;
using SQLite;
using System.Threading.Tasks;

namespace PCComponentes
{
	public class TorreRepository
    {
		public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

		public TorreRepository(string dbPath)
		{
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Tarjeta>().Wait();
		}

		public async Task AddNewTorreAsync(string id, string nombre, double precio)
		{
			int result = 0;
			try
			{
				//basic validation to ensure a name was entered
				if (string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(id) && precio>=0)
					throw new Exception("Incorrect data.");

                result = await conn.InsertAsync(new Torre() { Nombre = nombre , Id = id , Precio = precio});

				//StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, nombre);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add {0}. Error: {1}", nombre, ex.Message);
			}

		}

		public async Task<List<Torre>> GetAllTorreAsync()
		{
            List<Torre> lista = new List<Torre>();

            try
            {
                lista = await conn.Table<Torre>().ToListAsync();

            }
            catch (Exception ex)
            {
                StatusMessage = String.Format("Failed to retireve data. {0}", ex.Message);
            }

            return lista;
        }
	}
}