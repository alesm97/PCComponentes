using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PCComponentes.Models
{
    [Table("pedidos")]
    public class Pedido
    {
        [PrimaryKey]
        public int Id { get; set; }
        [NotNull]
        public int Placa { get; set; }
        [NotNull]
        public int Memoria { get; set; }
        [NotNull]
        public int Torre { get; set; }
        [NotNull]
        public int Micro { get; set; }
        [NotNull]
        public int Tarjeta { get; set; }
    }
}
