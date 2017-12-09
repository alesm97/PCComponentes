using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PCComponentes.Models
{
    [Table("pedido")]
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string UserId { get; set; }
        public string Placa { get; set; }
        public string Memoria { get; set; }
        public string Torre { get; set; }
        public string Micro { get; set; }
        public string Tarjeta { get; set; }
    }
}
