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
    public class TipoDocumentoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        //creamos una funcion para mostrar tipoDocumento
        public List<TipoDocumentoBO> MostrarTipoDocumento()
        {
            List<TipoDocumentoBO> tipos = new List<TipoDocumentoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarTipoDocumento";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoDocumentoBO obj = new TipoDocumentoBO();

                    //agregamos el objeto a la lista
                    obj.codigo = Convert.ToInt32(dr["codtipd"].ToString());
                    obj.nombre = dr["nomtipd"].ToString();
                    obj.estado = Convert.ToBoolean(dr["esttipd"].ToString());


                    tipos.Add(obj);
                }
                //devolvemos el valor de la lista
                return tipos;

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
        public List<TipoDocumentoBO> MostrarTipoDocumentoTodo()
        {

            List<TipoDocumentoBO> tipos = new List<TipoDocumentoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarTipoDocumentoTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoDocumentoBO obj = new TipoDocumentoBO();

                    //agregamos el objeto a la lista
                    obj.codigo = Convert.ToInt32(dr["codtipd"].ToString());
                    obj.nombre = dr["nomtipd"].ToString();
                    obj.estado = Convert.ToBoolean(dr["esttipd"].ToString());


                    tipos.Add(obj);
                }
                //devolvemos el valor de la lista
                return tipos;

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
        public bool RegistrarTipoDocumento(TipoDocumentoBO t)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_RegistrarTipoDocumento";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@nombre", t.nombre);
                cmd.Parameters.AddWithValue("@estado", t.estado);
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
        public bool ActualizarTipoDocumento(TipoDocumentoBO t)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_ActualizarTipoDocumento";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que actualizaremos por parametros
                cmd.Parameters.AddWithValue("@codigo", t.codigo);
                cmd.Parameters.AddWithValue("@nombre", t.nombre);
                cmd.Parameters.AddWithValue("@estado", t.estado);
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
        public bool EliminarTipoDocumento(TipoDocumentoBO t)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_EliminarTipoDocumento";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que eliminaremos por parametros
                cmd.Parameters.AddWithValue("@codigo", t.codigo);
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
        public bool HabilitarTipoDocumento(TipoDocumentoBO t)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_HabilitarTipoDocumento";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que habilitaremos por parametros
                cmd.Parameters.AddWithValue("@codigo", t.codigo);
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
        public int MostrarCodigoTipoDocumento()
        {
            //declaramos una funcion para el codigo
            int tipos = 0;
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_CodigoTipoDocumento";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //ejecutamos el procedimiento almacenado
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    tipos = (int)resultado;
                }
                return tipos;

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


