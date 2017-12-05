using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PCComponentes.Models
{
    [Table("memoria")]
    public class Memoria
    {
        [PrimaryKey]
        public string Id { get; set; }
        [MaxLength(250)]
        public string Nombre { get; set; }

        public double Precio { get; set; }

    }
}