using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pe.com.todobaratito.bo;

namespace pe.com.todobaratito.dal
{
    public class EmpleadoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        public bool ValidarEmpleado(EmpleadoBO e)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ValidarEmpleado";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@usuario", e.usuario);
                cmd.Parameters.AddWithValue("@clave", e.clave);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
                //devolvemos el valor de la lista
                return res;

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return res;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //creamos una funcion para mostrar producto
        public List<EmpleadoBO> MostrarEmpleado()
        {

            List<EmpleadoBO> empleados = new List<EmpleadoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarEmpleado";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmpleadoBO obj = new EmpleadoBO();
                    DistritoBO objdis = new DistritoBO();
                    RolBO objrol = new RolBO();
                    TipoDocumentoBO objtipd = new TipoDocumentoBO();
                    obj.codigo = Convert.ToInt32(dr["codemp"].ToString());
                    obj.nombre = dr["nomemp"].ToString();
                    obj.apellidopaterno = dr["apepemp"].ToString();
                    obj.apellidomaterno = dr["apememp"].ToString();
                    obj.documento = dr["docemp"].ToString();
                    obj.direccion = dr["diremp"].ToString();
                    obj.telefono = dr["telemp"].ToString();
                    obj.celular = dr["celemp"].ToString();
                    obj.correo = dr["coremp"].ToString();
                    obj.usuario = dr["usuemp"].ToString();
                    obj.clave = dr["claemp"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estemp"].ToString());

                    objdis.codigo = Convert.ToInt32(dr["coddis"].ToString());
                    objdis.nombre = dr["nomdis"].ToString();
                    obj.distrito = objdis;

                    objrol.codigo = Convert.ToInt32(dr["codrol"].ToString());
                    objrol.nombre = dr["nomrol"].ToString();
                    obj.rol = objrol;

                    objtipd.codigo = Convert.ToInt32(dr["codtipd"].ToString());
                    objtipd.nombre = dr["nomtipd"].ToString();
                    obj.tipodocumento = objtipd;


                    empleados.Add(obj);
                }
                //devolvemos el valor de la lista
                return empleados;

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }



        public List<EmpleadoBO> MostrarEmpleadoTodo()
        {

            List<EmpleadoBO> empleados = new List<EmpleadoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarEmpleadoTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmpleadoBO obj = new EmpleadoBO();
                    DistritoBO objdis = new DistritoBO();
                    RolBO objrol = new RolBO();
                    TipoDocumentoBO objtipd = new TipoDocumentoBO();
                    obj.codigo = Convert.ToInt32(dr["codemp"].ToString());
                    obj.nombre = dr["nomemp"].ToString();
                    obj.apellidopaterno = dr["apepemp"].ToString();
                    obj.apellidomaterno = dr["apememp"].ToString();
                    obj.documento = dr["docemp"].ToString();
                    obj.direccion = dr["diremp"].ToString();
                    obj.telefono = dr["telemp"].ToString();
                    obj.celular = dr["celemp"].ToString();
                    obj.correo = dr["coremp"].ToString();
                    obj.usuario = dr["usuemp"].ToString();
                    obj.clave = dr["claemp"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estemp"].ToString());

                    objdis.codigo = Convert.ToInt32(dr["coddis"].ToString());
                    objdis.nombre = dr["nomdis"].ToString();
                    obj.distrito = objdis;

                    objrol.codigo = Convert.ToInt32(dr["codrol"].ToString());
                    objrol.nombre = dr["nomrol"].ToString();
                    obj.rol = objrol;

                    objtipd.codigo = Convert.ToInt32(dr["codtipd"].ToString());
                    objtipd.nombre = dr["nomtipd"].ToString();
                    obj.tipodocumento = objtipd;


                    empleados.Add(obj);
                }
                //devolvemos el valor de la lista
                return empleados;

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }






        //creamos una funcion para registrar 
        public bool RegistrarEmpleado(EmpleadoBO e)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_RegistrarEmpleado";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@nombre", e.nombre);
                cmd.Parameters.AddWithValue("@apellidopaterno", e.apellidopaterno);
                cmd.Parameters.AddWithValue("@apellidomaterno", e.apellidomaterno);
                cmd.Parameters.AddWithValue("@documento", e.documento);
                cmd.Parameters.AddWithValue("@direccion", e.direccion);
                cmd.Parameters.AddWithValue("@telefono", e.telefono);
                cmd.Parameters.AddWithValue("@celular", e.celular);
                cmd.Parameters.AddWithValue("@correo", e.correo);
                cmd.Parameters.AddWithValue("@usuario", e.usuario);
                cmd.Parameters.AddWithValue("@clave", e.clave);
                cmd.Parameters.AddWithValue("@estado", e.estado);
                cmd.Parameters.AddWithValue("@coddis", e.distrito.codigo);
                cmd.Parameters.AddWithValue("@codrol", e.rol.codigo);
                cmd.Parameters.AddWithValue("@codtipd", e.tipodocumento.codigo);
                //ejecutamos el procedimiento almacenado
                res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }

        }

        //creamos una funcion para Actualizar
        public bool ActualizarEmpleado(EmpleadoBO e)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_ActualizarEmpleado";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", e.codigo);
                cmd.Parameters.AddWithValue("@nombre", e.nombre);
                cmd.Parameters.AddWithValue("@apellidopaterno", e.apellidopaterno);
                cmd.Parameters.AddWithValue("@apellidomaterno", e.apellidomaterno);
                cmd.Parameters.AddWithValue("@documento", e.documento);
                cmd.Parameters.AddWithValue("@direccion", e.direccion);
                cmd.Parameters.AddWithValue("@telefono", e.telefono);
                cmd.Parameters.AddWithValue("@celular", e.celular);
                cmd.Parameters.AddWithValue("@correo", e.correo);
                cmd.Parameters.AddWithValue("@usuario", e.usuario);
                cmd.Parameters.AddWithValue("@clave", e.clave);
                cmd.Parameters.AddWithValue("@estado", e.estado);
                cmd.Parameters.AddWithValue("@coddis", e.distrito.codigo);
                cmd.Parameters.AddWithValue("@codrol", e.rol.codigo);
                cmd.Parameters.AddWithValue("@codtipd", e.tipodocumento.codigo);
                //ejecutamos el procedimiento almacenado
                res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }

        }

        //creamos una funcion para Eliminar
        public bool EliminarEmpleado(EmpleadoBO e)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_EliminarEmpleado";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", e.codigo);
                //ejecutamos el procedimiento almacenado
                res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }

        }

        //creamos una funcion para Habilitar
        public bool HabilitarEmpleado(EmpleadoBO e)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_HabilitarEmpleado";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", e.codigo);
                //ejecutamos el procedimiento almacenado
                res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //creamos una funcion para Mostrar el codigo
        public int MostrarCodigoEmpleado()
        {
            //declaramos una funcion para el codigo
            int empleados = 0;
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_CodigoEmpleado";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //ejecutamos el procedimiento almacenado
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    empleados = (int)resultado;
                }
                return empleados;

            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                objconexion.CerrarConexion();
            }

        }
    }
}
