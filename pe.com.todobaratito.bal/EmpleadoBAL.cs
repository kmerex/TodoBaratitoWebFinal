using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pe.com.todobaratito.bo;
using pe.com.todobaratito.dal;

namespace pe.com.todobaratito.bal
{
    public class EmpleadoBAL
    {
        EmpleadoDAL dal = new EmpleadoDAL();
        public bool ValidarEmpleado(EmpleadoBO e)
        {
            return dal.ValidarEmpleado(e);
        }
        public List<EmpleadoBO> MostrarEmpleado()
        {
            return dal.MostrarEmpleado();
        }
        public List<EmpleadoBO> MostrarEmpleadoTodo()
        {
            return dal.MostrarEmpleadoTodo();
        }


        public bool RegistrarEmpleado(EmpleadoBO e)
        {
            return dal.RegistrarEmpleado(e);
        }

        public bool ActualizarEmpleado(EmpleadoBO e)
        {
            return dal.ActualizarEmpleado(e);
        }
        public bool EliminarEmpleado(EmpleadoBO e)
        {
            return dal.EliminarEmpleado(e);
        }
        public bool HabilitarEmpleado(EmpleadoBO e)
        {
            return dal.HabilitarEmpleado(e);
        }
        public int MostrarCodigoEmpleado()
        {
            return dal.MostrarCodigoEmpleado();
        }
    }
}