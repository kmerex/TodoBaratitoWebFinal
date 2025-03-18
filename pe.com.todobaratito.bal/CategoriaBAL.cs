using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pe.com.todobaratito.bo;
using pe.com.todobaratito.dal;

namespace pe.com.todobaratito.bal
{
    public class CategoriaBAL
    {
        //creamos un objeto de categoriaDAL 
        CategoriaDAL dal = new CategoriaDAL();

        //creamos una lista de tipo CategoriaBo
        public List<CategoriaBO> MostrarCategoria()
        {
            return dal.MostrarCategoria();
        }

        public List<CategoriaBO> MostrarCategoriaTodo()
        {
            return dal.MostrarCategoriaTodo();
        }

        public bool RegistrarCategoria(CategoriaBO c)
        {
            return dal.RegistrarCategoria(c);
        }
        public bool ActualizarCategoria(CategoriaBO c)
        {
            return dal.ActualizarCategoria(c);
        }

        public bool EliminarCategoria(CategoriaBO c)
        {
            return dal.EliminarCategoria(c);
        }

        public bool HabilitarCategoria(CategoriaBO c)
        {
            return dal.HabilitarCategoria(c);
        }
        public int MostrarCodigoCategoria()
        {
            return dal.MostrarCodigoCategoria();
        }

    }
}
