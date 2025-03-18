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
    public class ProductoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        //creamos una funcion para mostrar producto
        public List<ProductoBO> MostrarProducto()
        {
            List<ProductoBO> productos = new List<ProductoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarProducto";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ProductoBO obj = new ProductoBO();
                    MarcaBO objmar = new MarcaBO();
                    CategoriaBO objcat = new CategoriaBO();
                    obj.codigo = Convert.ToInt32(dr["codpro"].ToString());
                    obj.nombre = dr["nompro"].ToString();
                    obj.descripcion = dr["despro"].ToString();
                    obj.precio = Convert.ToDouble(dr["prepro"].ToString());
                    obj.cantidad = Convert.ToInt32(dr["canpro"].ToString());
                    obj.estado = Convert.ToBoolean(dr["estpro"].ToString());

                    objmar.codigo = Convert.ToInt32(dr["codmar"].ToString());
                    objmar.nombre = dr["nommar"].ToString();
                    obj.marca = objmar;

                    objcat.codigo = Convert.ToInt32(dr["codcat"].ToString());
                    objcat.nombre = dr["nomcat"].ToString();
                    obj.categoria = objcat;


                    productos.Add(obj);
                }
                //devolvemos el valor de la lista
                return productos;

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


        public List<ProductoBO> MostrarProductoTodo()
        {

            List<ProductoBO> productos = new List<ProductoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarProductoTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ProductoBO obj = new ProductoBO();
                    MarcaBO objmar = new MarcaBO();
                    CategoriaBO objcat = new CategoriaBO();
                    obj.codigo = Convert.ToInt32(dr["codpro"].ToString());
                    obj.nombre = dr["nompro"].ToString();
                    obj.descripcion = dr["despro"].ToString();
                    obj.precio = Convert.ToDouble(dr["prepro"].ToString());
                    obj.cantidad = Convert.ToInt32(dr["canpro"].ToString());
                    obj.estado = Convert.ToBoolean(dr["estpro"].ToString());

                    objmar.codigo = Convert.ToInt32(dr["codmar"].ToString());
                    objmar.nombre = dr["nommar"].ToString();
                    obj.marca = objmar;

                    objcat.codigo = Convert.ToInt32(dr["codcat"].ToString());
                    objcat.nombre = dr["nomcat"].ToString();
                    obj.categoria = objcat;


                    productos.Add(obj);
                }
                //devolvemos el valor de la lista
                return productos;

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
        public bool RegistrarProducto(ProductoBO p)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_RegistrarProducto";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.descripcion);
                cmd.Parameters.AddWithValue("@precio", p.precio);
                cmd.Parameters.AddWithValue("@cantidad", p.cantidad);
                cmd.Parameters.AddWithValue("@estado", p.estado);
                cmd.Parameters.AddWithValue("@codmar", p.marca.codigo);
                cmd.Parameters.AddWithValue("@codcat", p.categoria.codigo);
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
        public bool ActualizarProducto(ProductoBO p)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_ActualizarProducto";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", p.codigo);
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.descripcion);
                cmd.Parameters.AddWithValue("@precio", p.precio);
                cmd.Parameters.AddWithValue("@cantidad", p.cantidad);
                cmd.Parameters.AddWithValue("@estado", p.estado);
                cmd.Parameters.AddWithValue("@codmar", p.marca.codigo);
                cmd.Parameters.AddWithValue("@codcat", p.categoria.codigo);
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
        public bool EliminarProducto(ProductoBO p)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_EliminarProducto";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", p.codigo);
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
        public bool HabilitarProducto(ProductoBO p)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_HabilitarProducto";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", p.codigo);
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
        public int MostrarCodigoProducto()
        {
            //declaramos una funcion para el codigo
            int productos = 0;
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_CodigoProducto";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //ejecutamos el procedimiento almacenado
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    productos = (int)resultado;
                }
                return productos;

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

