using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCComponentes.Models
{
    class ListaPedidoItem
    {
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string NombreUsuario { get; set; }
        /// <summary>
        /// Nombre de la placa base.
        /// </summary>
        public string NombrePlaca { get; set; }
        /// <summary>
        /// Nombre del microprocesador.
        /// </summary>
        public string NombreMicroprocesador { get; set; }
        /// <summary>
        /// Nombre de la torre.
        /// </summary>
        public string NombreTorre { get; set; }
        /// <summary>
        /// Nombre de la memoria.
        /// </summary>
        public string NombreMemoria { get; set; }
        /// <summary>
        /// Nombre de la tarjeta grafica.
        /// </summary>
        public string NombreTarjetaGrafica { get; set; }
        /// <summary>
        /// Precio del pedido
        /// </summary>
        public double PrecioPedido { get; set; }
    }
}
