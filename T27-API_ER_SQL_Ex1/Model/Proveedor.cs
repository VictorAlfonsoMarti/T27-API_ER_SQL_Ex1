using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_Ex1.Model
{
    public class Proveedor
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public string Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Suministra> Suministros { get; set; }


        //CONSTRUCTOR
        public Proveedor()
        {
            Suministros = new HashSet<Suministra>();
        }
    }
}
