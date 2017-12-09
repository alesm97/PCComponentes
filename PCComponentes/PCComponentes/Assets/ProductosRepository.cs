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

        /// <summary>
        /// Obtener todos los productos
        /// </summary>
        /// <returns>lista de productos</returns>
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

        /// <summary>
        /// Obtener todos los microprocesadores
        /// </summary>
        /// <returns>lista de microprocesadores</returns>
        public async Task<List<Producto>> GetAllMicrosAsync()
        {
            List<Producto> lista = new List<Producto>();
            List<Producto> micros = new List<Producto>();

            try
            {
                lista = await conn.Table<Producto>().ToListAsync();

                micros = lista.Where(t => t.Tipo == "micro").ToList();

            }
            catch (Exception ex)
            {

            }

            return micros;
        }

        /// <summary>
        /// Obtener todos las memorias
        /// </summary>
        /// <returns>lista de memorias</returns>
        public async Task<List<Producto>> GetAllMemoriasAsync()
        {
            List<Producto> lista = new List<Producto>();
            List<Producto> memorias = new List<Producto>();

            try
            {
                lista = await conn.Table<Producto>().ToListAsync();

                memorias = lista.Where(t => t.Tipo == "memoria").ToList();

            }
            catch (Exception ex)
            {

            }

            return memorias;
        }

        /// <summary>
        /// Obtener todos los placas
        /// </summary>
        /// <returns>lista de placas</returns>
        public async Task<List<Producto>> GetAllPlacaAsync()
        {
            List<Producto> lista = new List<Producto>();
            List<Producto> placas = new List<Producto>();

            try
            {
                lista = await conn.Table<Producto>().ToListAsync();

                placas = lista.Where(t => t.Tipo == "placa").ToList();

            }
            catch (Exception ex)
            {

            }

            return placas;
        }

        /// <summary>
        /// Obtener todos las torres
        /// </summary>
        /// <returns>lista de torres</returns>
        public async Task<List<Producto>> GetAllTorresAsync()
        {
            List<Producto> lista = new List<Producto>();
            List<Producto> torres = new List<Producto>();

            try
            {
                lista = await conn.Table<Producto>().ToListAsync();

                torres = lista.Where(t => t.Tipo == "torre").ToList();

            }
            catch (Exception ex)
            {

            }

            return torres;
        }

        /// <summary>
        /// Obtener todos las tarjetas
        /// </summary>
        /// <returns>lista de tarjetas</returns>
        public async Task<List<Producto>> GetAllTarjetasAsync()
        {
            List<Producto> lista = new List<Producto>();
            List<Producto> tarjetas = new List<Producto>();

            try
            {
                lista = await conn.Table<Producto>().ToListAsync();

                tarjetas = lista.Where(t => t.Tipo == "tarjeta").ToList();

            }
            catch (Exception ex)
            {

            }

            return tarjetas;
        }
    }
}