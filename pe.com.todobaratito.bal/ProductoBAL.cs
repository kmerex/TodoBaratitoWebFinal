using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pe.com.todobaratito.bo;
using pe.com.todobaratito.dal;

namespace pe.com.todobaratito.bal
{
    public class ProductoBAL
    {
        //creamos un objeto de ProductoDAL 
        ProductoDAL dal = new ProductoDAL();

        //creamos una lista de tipo ProdcutoBo
        public List<ProductoBO> MostrarProducto()
        {
            return dal.MostrarProducto();
        }

        public List<ProductoBO> MostrarProductoTodo()
        {
            return dal.MostrarProductoTodo();
        }

        public bool RegistrarProducto(ProductoBO p)
        {
            return dal.RegistrarProducto(p);
        }
        public bool ActualizarProducto(ProductoBO p)
        {
            return dal.ActualizarProducto(p);
        }

        public bool EliminarProducto(ProductoBO p)
        {
            return dal.EliminarProducto(p);
        }

        public bool HabilitarProducto(ProductoBO p)
        {
            return dal.HabilitarProducto(p);
        }
        public int MostrarCodigoProducto()
        {
            return dal.MostrarCodigoProducto();
        }
    }
}

