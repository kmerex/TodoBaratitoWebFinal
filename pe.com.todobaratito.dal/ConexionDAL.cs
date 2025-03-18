using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.todobaratito.dal
{
    public class ConexionDAL
    {
        //cadena de conexion
        //con autenticacion de windows para SQL SERVER
        private string cadena = "Data Source=DESKTOP-C2SF078; Initial Catalog=bdtodobaratito2025; User ID=sa; Password=Quirofano20%; TrustServerCertificate=True;";

        //Crear un objeto de tipo SQLConnection
        private SqlConnection xcon;

        //Creamos una funcion para conectarnos a la BD

        public SqlConnection Conectar()
        {
            //instanciamos la conexiond e la cadena 
            xcon = new SqlConnection(cadena);
            //Abrimos la conexion 
            xcon.Open();
            //devolvemos la conexion abierta
            return xcon;
        }

        // Creamos un procedimiento para cerrar
        public void CerrarConexion()
        {
            //cerramos la conexion
            xcon.Close();
            //liberamos los recursos
            xcon.Dispose();
        }
    }

}

