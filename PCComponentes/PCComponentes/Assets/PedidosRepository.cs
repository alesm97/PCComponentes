using System;
using System.Collections.Generic;
using System.Linq;
using PCComponentes.Models;
using SQLite;
using System.Threading.Tasks;

namespace PCComponentes
{
	public class PedidosRepository
	{
		public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

		public PedidosRepository(string dbPath)
		{
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Pedido>().Wait();
		}

        /// <summary>
        /// Añadir nuevo pedido
        /// </summary>
        /// <param name="idUser">id usuario</param>
        /// <param name="idPlaca">placa</param>
        /// <param name="idMemoria">memoria</param>
        /// <param name="idTorre">torre</param>
        /// <param name="idMicro">micro</param>
        /// <param name="idTarjeta">tarjeta</param>
        /// <returns></returns>
		public async Task AddNewPedidoAsync(string idUser, string idPlaca, string idMemoria, string idTorre, string idMicro, string idTarjeta)
		{

			int result = 0;
			try
            { 
                result = await conn.InsertAsync(new Pedido() { UserId = idUser , Placa = idPlaca , Memoria = idMemoria, Torre = idTorre, Micro = idMicro, Tarjeta = idTarjeta });
			}
			catch (Exception ex)
			{
				
			}

		}

        /// <summary>
        /// Obtener todos los pedidos
        /// </summary>
        /// <returns>lista de pedidos</returns>
		public async Task<List<Pedido>> GetAllPedidosAsync()
		{
            List<Pedido> lista = new List<Pedido>();

            try
            {
                lista = await conn.Table<Pedido>().ToListAsync();

            }
            catch (Exception ex)
            {
                
            }

            return lista;
        }
	}
}