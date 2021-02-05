using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_Ex1.Model
{
    public class Pieza
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public ICollection<Suministra> Suministros { get; set; }

        //CONSTRUCTOR
        public Pieza()
        {
            Suministros = new HashSet<Suministra>();
        }
    }
}
