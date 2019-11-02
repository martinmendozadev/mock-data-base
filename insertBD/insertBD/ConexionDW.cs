/* Importamos las Librerias Necesarias para Trabajar */
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertBD
{
    class ConexionDW{
        private SqlConnection conectarbd=new SqlConnection(); // Obj Conexion
        private string cadena = "Data Source=MENDOZA\\SQLEXPRESS;Initial Catalog=Data_WereHouse; Integrated Security=True";

        public ConexionDW(){
            conectarbd.ConnectionString = cadena;
        }

        public void Abrir(){ // Metodo para Abrir la Conexion
            conectarbd.Open();
        }

        public void Cerrar(){ // Metodo para Cerrar la Conexion
            conectarbd.Close();
        }

        public Int32 registrosTiempo()
        {
            Int32 registros = 0;
            SqlCommand comando = new SqlCommand("SELECT count(idTiempo) FROM tiempo");
            comando.Connection = conectarbd;
            registros = Convert.ToInt32(comando.ExecuteScalar());

            return registros;
        }

        public void cargaraTiempo(String idTiempo, Int32 año, Int32 Semestre, Int32 Trimestre, Int32 mes, Int32 quincena, Int32 semana, Int32 dia, DateTime fecha)
        {
            //Instruccion SQL para insertar en la BD.
            SqlCommand comando = new SqlCommand("INSERT INTO dim_tiempo values (@idTiempo,@año,@Semestre,@Trimestre,@mes,@quincena,@semana,@dia,@fecha)");
            //Cargo mi instruccion SQL a Conexion.
            comando.Connection = conectarbd;

            //Asigno valores a los paremetros de la sentencia SQL
            SqlParameter parametro1 = new SqlParameter();
            parametro1.ParameterName = "@idTiempo";
            parametro1.Value = idTiempo;

            SqlParameter parametro2 = new SqlParameter();
            parametro2.ParameterName = "@año";
            parametro2.Value = año;

            SqlParameter parametro3 = new SqlParameter();
            parametro3.ParameterName = "@Semestre";
            parametro3.Value = Semestre;

            SqlParameter parametro4 = new SqlParameter();
            parametro4.ParameterName = "@Trimestre";
            parametro4.Value = Trimestre;

            SqlParameter parametro5 = new SqlParameter();
            parametro5.ParameterName = "@mes";
            parametro5.Value = mes;

            SqlParameter parametro6 = new SqlParameter();
            parametro6.ParameterName = "@quincena";
            parametro6.Value = quincena;

            SqlParameter parametro7 = new SqlParameter();
            parametro7.ParameterName = "@semana";
            parametro7.Value = semana;

            SqlParameter parametro8 = new SqlParameter();
            parametro8.ParameterName = "@dia";
            parametro8.Value = dia;

            SqlParameter parametro9 = new SqlParameter();
            parametro9.ParameterName = "@fecha";
            parametro9.Value = fecha;

            //Cargo cada valor de los pareametros al comando SQL
            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.Parameters.Add(parametro4);
            comando.Parameters.Add(parametro5);
            comando.Parameters.Add(parametro6);
            comando.Parameters.Add(parametro7);
            comando.Parameters.Add(parametro8);
            comando.Parameters.Add(parametro9);

            //Ejecuto la sentencia SQL
            comando.ExecuteNonQuery();
        }

        public DataSet Ejecutar(string Comando, string Tabla){ // Metodo para Ejecutar Comandos
            SqlDataAdapter CMD = new SqlDataAdapter(Comando, conectarbd); // Creamos un DataAdapter con el Comando y la Conexion
            DataSet DS = new DataSet(); // Creamos el DataSet que Devolvera el Metodo
            CMD.Fill(DS, Tabla); // Ejecutamos el Comando en la Tabla
        
            return DS; // Regresamos el DataSet
        }

    } // Fin de la Clase
}