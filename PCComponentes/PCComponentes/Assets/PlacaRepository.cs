using System;
using System.Collections.Generic;
using System.Linq;
using PruebaSQLite1.Models;
using SQLite;
using System.Threading.Tasks;

namespace PCComponentes
{
	public class PlacaRepository
	{
		public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

		public PlacaRepository(string dbPath)
		{
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Placa>().Wait();
		}

		public async Task AddNewPersonAsync(string name)
		{
			int result = 0;
			try
			{
				//basic validation to ensure a name was entered
				if (string.IsNullOrEmpty(name))
					throw new Exception("Valid name required");

                result = await conn.InsertAsync(new Person() { Name = name });

				StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
			}

		}

		public async Task<List<Person>> GetAllPlacasAsync()
		{
            List<Placa> lista = new List<Placa>();

            try
            {
                lista = await conn.Table<Placa>().ToListAsync();

            }
            catch (Exception ex)
            {
                StatusMessage = String.Format("Failed to retireve data. {0}", ex.Message);
            }

            return lista;
        }
	}
}