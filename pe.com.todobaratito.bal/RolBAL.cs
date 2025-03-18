using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pe.com.todobaratito.bo;
using pe.com.todobaratito.dal;

namespace pe.com.todobaratito.bal
{
    public class RolBAL
    {
        RolDAL dal = new RolDAL();

        //creamos una lista de tipo ProdcutoBo
        public List<RolBO> MostrarRol()
        {
            return dal.MostrarRol();
        }
        public List<RolBO> MostrarRolTodo()
        {
            return dal.MostrarRolTodo();
        }

        public bool RegistrarRol(RolBO r)
        {
            return dal.RegistrarRol(r);
        }
        public bool ActualizarRol(RolBO r)
        {
            return dal.ActualizarRol(r);
        }
        public bool EliminarRol(RolBO r)
        {
            return dal.EliminarRol(r);
        }

        public bool HabilitarRol(RolBO r)
        {
            return dal.HabilitarRol(r);
        }

        public int MostrarCodigoRol()
        {
            return dal.MostrarCodigoRol();
        }

    }
}
