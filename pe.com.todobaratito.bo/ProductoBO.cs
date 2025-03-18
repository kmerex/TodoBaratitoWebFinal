using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.todobaratito.bo
{
    public class ProductoBO
    {
        public int codigo { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public double precio { get; set; }
        public int cantidad { get; set; }

        public bool estado { get; set; }
        public CategoriaBO categoria { get; set; }
        public MarcaBO marca { get; set; }
    }
}
