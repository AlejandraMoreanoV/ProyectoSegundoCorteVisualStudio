using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SegundoProyectoVisualStudio
{
    internal class Sede
    {
        public int id { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public DateTime fechaRegistro { get; set; }
        public double m2 { get; set; }

        public List<Usuario> listaUsuarios { get; set; }

    }
}
