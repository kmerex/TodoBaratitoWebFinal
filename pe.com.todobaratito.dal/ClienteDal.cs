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
    public class ClienteDal
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        //creamos una funcion para mostrar producto
        public List<ClienteBO> MostrarCliente()
        {

            List<ClienteBO> clientes = new List<ClienteBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarCliente";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClienteBO obj = new ClienteBO();
                    DistritoBO objdis = new DistritoBO();
                    TipoDocumentoBO objtipd = new TipoDocumentoBO();
                    obj.codigo = Convert.ToInt32(dr["codcli"].ToString());
                    obj.nombre = dr["nomcli"].ToString();
                    obj.apellidopaterno = dr["apepcli"].ToString();
                    obj.apellidomaterno = dr["apemcli"].ToString();
                    obj.documento = dr["doccli"].ToString();
                    obj.direccion = dr["dircli"].ToString();
                    obj.telefono = dr["telcli"].ToString();
                    obj.celular = dr["celcli"].ToString();
                    obj.correo = dr["corcli"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estcli"].ToString());

                    objdis.codigo = Convert.ToInt32(dr["coddis"].ToString());
                    objdis.nombre = dr["nomdis"].ToString();
                    obj.distrito = objdis;

                    objtipd.codigo = Convert.ToInt32(dr["codtipd"].ToString());
                    objtipd.nombre = dr["nomtipd"].ToString();
                    obj.tipodocumento = objtipd;


                    clientes.Add(obj);
                }
                //devolvemos el valor de la lista
                return clientes;

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

        public List<ClienteBO> MostrarClienteTodo()
        {

            List<ClienteBO> clientes = new List<ClienteBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarClienteTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClienteBO obj = new ClienteBO();
                    DistritoBO objdis = new DistritoBO();
                    TipoDocumentoBO objtipd = new TipoDocumentoBO();
                    obj.codigo = Convert.ToInt32(dr["codcli"].ToString());
                    obj.nombre = dr["nomcli"].ToString();
                    obj.apellidopaterno = dr["apepcli"].ToString();
                    obj.apellidomaterno = dr["apemcli"].ToString();
                    obj.documento = dr["doccli"].ToString();
                    obj.direccion = dr["dircli"].ToString();
                    obj.telefono = dr["telcli"].ToString();
                    obj.celular = dr["celcli"].ToString();
                    obj.correo = dr["corcli"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estcli"].ToString());

                    objdis.codigo = Convert.ToInt32(dr["coddis"].ToString());
                    objdis.nombre = dr["nomdis"].ToString();
                    obj.distrito = objdis;

                    objtipd.codigo = Convert.ToInt32(dr["codtipd"].ToString());
                    objtipd.nombre = dr["nomtipd"].ToString();
                    obj.tipodocumento = objtipd;


                    clientes.Add(obj);
                }
                //devolvemos el valor de la lista
                return clientes;

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
        public bool RegistrarCliente(ClienteBO c)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_RegistrarCliente";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@apellidopaterno", c.apellidopaterno);
                cmd.Parameters.AddWithValue("@apellidomaterno", c.apellidomaterno);
                cmd.Parameters.AddWithValue("@documento", c.documento);
                cmd.Parameters.AddWithValue("@direccion", c.direccion);
                cmd.Parameters.AddWithValue("@telefono", c.telefono);
                cmd.Parameters.AddWithValue("@celular", c.celular);
                cmd.Parameters.AddWithValue("@correo", c.correo);
                cmd.Parameters.AddWithValue("@estado", c.estado);
                cmd.Parameters.AddWithValue("@coddis", c.distrito.codigo);
                cmd.Parameters.AddWithValue("@codtipd", c.tipodocumento.codigo);
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
        public bool ActualizarCliente(ClienteBO c)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_ActualizarCliente";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@apellidopaterno", c.apellidopaterno);
                cmd.Parameters.AddWithValue("@apellidomaterno", c.apellidomaterno);
                cmd.Parameters.AddWithValue("@documento", c.documento);
                cmd.Parameters.AddWithValue("@direccion", c.direccion);
                cmd.Parameters.AddWithValue("@telefono", c.telefono);
                cmd.Parameters.AddWithValue("@celular", c.celular);
                cmd.Parameters.AddWithValue("@correo", c.correo);
                cmd.Parameters.AddWithValue("@estado", c.estado);
                cmd.Parameters.AddWithValue("@coddis", c.distrito.codigo);
                cmd.Parameters.AddWithValue("@codtipd", c.tipodocumento.codigo);
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
        public bool EliminarCliente(ClienteBO c)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_EliminarCliente";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
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
        public bool HabilitarCliente(ClienteBO c)
        {
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_HabilitarCliente";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos qye registraremos por parametros
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
        public int MostrarCodigoCliente()
        {
            //declaramos una funcion para el codigo
            int clientes = 0;
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_CodigoCliente";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //ejecutamos el procedimiento almacenado
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    clientes = (int)resultado;
                }
                return clientes;

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
