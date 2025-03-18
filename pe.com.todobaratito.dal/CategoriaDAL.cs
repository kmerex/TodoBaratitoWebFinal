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
    public class CategoriaDAL
    {
        //se crea un objeto de la clase conexion
        private ConexionDAL objconexion = new ConexionDAL();
        // Creamos un objeto SQlCommand para los comandos SQL
        private SqlCommand cmd;
        //creamos un objeto de tipo SqlDataReader para cargar datos
        private SqlDataReader dr;
        //creamos una variable para los resultados de SQL de Actualizacion
        int res = 0;

        //creamos una funcion para mostrar categoria de tipo List
        public List<CategoriaBO> MostrarCategoria()
        {
            //creamos una lista de tipo CategoriaBO
            List<CategoriaBO> categorias = new List<CategoriaBO>();
            //utlizamos el manejo de excepciones
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_MostrarCategoria";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //ejecutamos la consulta y el resultado lo guardamos en el SqlDataReader
                dr = cmd.ExecuteReader();
                //cargamos los datos del SqlDataReader en la lista
                while (dr.Read())
                {
                    //creamos un objeto de CategoriaBO
                    CategoriaBO obj = new CategoriaBO();
                    //leemos los datos y asignamos al objeto
                    obj.codigo = Convert.ToInt32(dr["codcat"].ToString());
                    obj.nombre = dr["nomcat"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estcat"].ToString());
                    //agregamos el objeto a la lista
                    categorias.Add(obj);
                }
                //devolvemos el valor de la lista
                return categorias;

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

        public List<CategoriaBO> MostrarCategoriaTodo()
        {

            List<CategoriaBO> categorias = new List<CategoriaBO>();

            try
            {

                cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_MostrarCategoriaTodo";

                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    CategoriaBO obj = new CategoriaBO();

                    obj.codigo = Convert.ToInt32(dr["codcat"].ToString());
                    obj.nombre = dr["nomcat"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estcat"].ToString());

                    categorias.Add(obj);
                }

                return categorias;

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
        public bool RegistrarCategoria(CategoriaBO c)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_RegistrarCategoria";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@estado", c.estado);
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
        public bool ActualizarCategoria(CategoriaBO c)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_ActualizarCategoria";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que actualizaremos por parametros
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@estado", c.estado);
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
        public bool EliminarCategoria(CategoriaBO c)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_EliminarCategoria";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que eliminaremos por parametros
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
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
        public bool HabilitarCategoria(CategoriaBO c)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_HabilitarCategoria";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que habilitaremos por parametros
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
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
        public int MostrarCodigoCategoria()
        {
            //declaramos una funcion para el codigo
            int categorias = 0;
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_CodigoCategoria";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //ejecutamos el procedimiento almacenado
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    categorias = (int)resultado;
                }
                return categorias;

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
