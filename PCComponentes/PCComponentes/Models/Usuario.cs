using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PCComponentes.Models
{
    [Table("usuario")]
    public class Usuario
    {

        [PrimaryKey,MaxLength(4)]
        public string Id { get; set; }
        [MaxLength(25),NotNull]
        public string Nombre { get; set; }
        [MaxLength(15),NotNull]
        public string Password { get; set; }
        [MaxLength(7),NotNull]
        public string Tipo { get; set; }

    }
}
