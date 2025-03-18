using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pe.com.todobaratito.bo;
using pe.com.todobaratito.dal;

namespace pe.com.todobaratito.bal
{
    public class DistritoBAL
    {
        DistritoDAL dal = new DistritoDAL();
        public List<DistritoBO> MostrarDistrito()
        {
            return dal.MostrarDistrito();
        }

        public List<DistritoBO> MostrarDistritoTodo()
        {
            return dal.MostrarDistritoTodo();

        }

        public bool RegistrarDistrito(DistritoBO d)
        {
            return dal.RegistrarDistrito(d);
        }
        public bool ActualizarDistrito(DistritoBO d)
        {
            return dal.ActualizarDistrito(d);
        }

        public bool EliminarDistrito(DistritoBO d)
        {
            return dal.EliminarDistrito(d);
        }
        public bool HabilitarDistrito(DistritoBO d)
        {
            return dal.HabilitarDistrito(d);
        }

        public int MostrarCodigoDistrito()
        {
            return dal.MostrarCodigoDistrito();
        }
    }
}
