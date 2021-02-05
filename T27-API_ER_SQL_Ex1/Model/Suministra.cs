using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_Ex1.Model
{
    public class Suministra
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public int CodigoPieza { get; set; }
        public string IdProveedor { get; set; }
        public int Precio { get; set; }

        public Pieza Pieza { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
