/* Importamos las Librerias Necesarias para Trabajar */
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace insertBD
{
    class ConexionDW{
        private SqlConnection Con; // Obj Conexion

        public ConexionDW(){
            string url = "Server=localhost; User id=root; Database=BD_Operacional_Ventas; Password=;"; // Contendra los Datos las Conexion.
            Con.ConnectionString = url;
        }

        public void Abrir(){ // Metodo para Abrir la Conexion
            Con.Open();
        }

        public void Cerrar(){ // Metodo para Cerrar la Conexion
            Con.Close();
        }

        public DataSet Ejecutar(string Comando, string Tabla){ // Metodo para Ejecutar Comandos
            SqlDataAdapter CMD = new SqlDataAdapter(Comando, Con); // Creamos un DataAdapter con el Comando y la Conexion
            DataSet DS = new DataSet(); // Creamos el DataSet que Devolvera el Metodo
            CMD.Fill(DS, Tabla); // Ejecutamos el Comando en la Tabla
        
            return DS; // Regresamos el DataSet
        }

    } // Fin de la Clase
}