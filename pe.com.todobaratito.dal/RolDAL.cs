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
    public class RolDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        //creamos una funcion para mostrar rol
        public List<RolBO> MostrarRol()
        {
            List<RolBO> roles = new List<RolBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarRol";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RolBO obj = new RolBO();

                    //agregamos el objeto a la lista
                    obj.codigo = Convert.ToInt32(dr["codrol"].ToString());
                    obj.nombre = dr["nomrol"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estrol"].ToString());


                    roles.Add(obj);
                }
                //devolvemos el valor de la lista
                return roles;

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
        public List<RolBO> MostrarRolTodo()
        {

            List<RolBO> roles = new List<RolBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarRolTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RolBO obj = new RolBO();

                    //agregamos el objeto a la lista
                    obj.codigo = Convert.ToInt32(dr["codrol"].ToString());
                    obj.nombre = dr["nomrol"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estrol"].ToString());


                    roles.Add(obj);
                }
                //devolvemos el valor de la lista
                return roles;

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
        public bool RegistrarRol(RolBO r)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_RegistrarRol";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@nombre", r.nombre);
                cmd.Parameters.AddWithValue("@estado", r.estado);
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
        public bool ActualizarRol(RolBO r)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_ActualizarRol";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que actualizaremos por parametros
                cmd.Parameters.AddWithValue("@codigo", r.codigo);
                cmd.Parameters.AddWithValue("@nombre", r.nombre);
                cmd.Parameters.AddWithValue("@estado", r.estado);
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
        public bool EliminarRol(RolBO r)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_EliminarRol";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que eliminaremos por parametros
                cmd.Parameters.AddWithValue("@codigo", r.codigo);
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
        public bool HabilitarRol(RolBO r)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_HabilitarRol";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que habilitaremos por parametros
                cmd.Parameters.AddWithValue("@codigo", r.codigo);
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
        public int MostrarCodigoRol()
        {
            //declaramos una funcion para el codigo
            int roles = 0;
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_CodigoRol";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //ejecutamos el procedimiento almacenado
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    roles = (int)resultado;
                }
                return roles;

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

