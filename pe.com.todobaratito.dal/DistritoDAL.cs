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
    public class DistritoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        //creamos una funcion para mostrar producto
        public List<DistritoBO> MostrarDistrito()
        {
            List<DistritoBO> distritos = new List<DistritoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarDistrito";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DistritoBO obj = new DistritoBO();

                    //agregamos el objeto a la lista
                    obj.codigo = Convert.ToInt32(dr["coddis"].ToString());
                    obj.nombre = dr["nomdis"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estdis"].ToString());


                    distritos.Add(obj);
                }
                //devolvemos el valor de la lista
                return distritos;

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
        public List<DistritoBO> MostrarDistritoTodo()
        {

            List<DistritoBO> distritos = new List<DistritoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarDistritoTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DistritoBO obj = new DistritoBO();

                    //agregamos el objeto a la lista
                    obj.codigo = Convert.ToInt32(dr["coddis"].ToString());
                    obj.nombre = dr["nomdis"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estdis"].ToString());


                    distritos.Add(obj);
                }
                //devolvemos el valor de la lista
                return distritos;

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


        //creamos una funcion ara registrar 
        public bool RegistrarDistrito(DistritoBO d)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_RegistrarDistrito";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@nombre", d.nombre);
                cmd.Parameters.AddWithValue("@estado", d.estado);
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
        public bool ActualizarDistrito(DistritoBO d)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_ActualizarDistrito";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que actualizaremos por parametros
                cmd.Parameters.AddWithValue("@codigo", d.codigo);
                cmd.Parameters.AddWithValue("@nombre", d.nombre);
                cmd.Parameters.AddWithValue("@estado", d.estado);
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
        public bool EliminarDistrito(DistritoBO d)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_EliminarDistrito";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que eliminaremos por parametros
                cmd.Parameters.AddWithValue("@codigo", d.codigo);
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
        public bool HabilitarDistrito(DistritoBO d)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_HabilitarDistrito";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que habilitaremos por parametros
                cmd.Parameters.AddWithValue("@codigo", d.codigo);
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
        public int MostrarCodigoDistrito()
        {
            //declaramos una funcion para el codigo
            int distritos = 0;
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_CodigoDistrito";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //ejecutamos el procedimiento almacenado
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    distritos = (int)resultado;
                }
                return distritos;

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

