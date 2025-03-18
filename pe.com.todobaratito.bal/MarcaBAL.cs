using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pe.com.todobaratito.bo;
using pe.com.todobaratito.dal;

namespace pe.com.todobaratito.bal
{
    public class MarcaBAL
    {
        MarcaDAL dal = new MarcaDAL();

        //creamos una lista de tipo ProdcutoBo
        public List<MarcaBO> MostrarMarca()
        {
            return dal.MostrarMarca();
        }

        public List<MarcaBO> MostrarMarcaTodo()
        {
            return dal.MostrarMarcaTodo();
        }

        public bool RegistrarMarca(MarcaBO m)
        {
            return dal.RegistrarMarca(m);
        }
        public bool ActualizarMarca(MarcaBO m)
        {
            return dal.ActualizarMarca(m);
        }
        public bool EliminarMarca(MarcaBO m)
        {
            return dal.EliminarMarca(m);
        }
        public bool HabilitarMarca(MarcaBO m)
        {
            return dal.HabilitarMarca(m);
        }
        public int MostrarCodigoMarca()
        {
            return dal.MostrarCodigoMarca();
        }
    }
}

