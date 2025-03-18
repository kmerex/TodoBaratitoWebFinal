using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.todobaratito.bo
{
    public class EmpleadoBO
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellidopaterno { get; set; }
        public string apellidomaterno { get; set; }
        public string documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }

        public bool estado { get; set; }
        public DistritoBO distrito { get; set; }
        public RolBO rol { get; set; }
        public TipoDocumentoBO tipodocumento { get; set; }
    }
}
