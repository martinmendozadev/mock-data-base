using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace insertBD
{
    class ConexionDW2
    {
        private MySqlConnection Con; // Obj Conexion

        public ConexionDW2(){
            // Contendra los Datos las Conexion.
            Con = new MySqlConnection("Server=localhost; User id=root; Database=BD_werehouse; Password=;");
        }

        public void Abrir(){ // Metodo para Abrir la Conexion
            Con.Open();
        }

        public void Cerrar(){ // Metodo para Cerrar la Conexion
            Con.Close();
        }

        public Int32 registrosTiempo()
        {
            Int32 registros = 0;
            MySqlCommand comando = new MySqlCommand("SELECT count(idTiempo) FROM dim_tiempo");
            comando.Connection = Con;
            registros = Convert.ToInt32(comando.ExecuteScalar());

            return registros;
        }

        public void cargaraTiempo(String idTiempo, Int32 año, Int32 Semestre, Int32 Trimestre, Int32 mes, Int32 quincena, Int32 semana, Int32 dia, DateTime fecha)
        {
            //Instruccion SQL para insertar en la BD.
            MySqlCommand comando = new MySqlCommand("INSERT INTO dim_tiempo values (@idTiempo,@año,@Semestre,@Trimestre,@mes,@quincena,@semana,@dia,@fecha)");
            //Cargo mi instruccion SQL a Conexion.
            comando.Connection = Con;

            //Asigno valores a los paremetros de la sentencia SQL
            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@idTiempo";
            parametro1.Value = idTiempo;

            MySqlParameter parametro2 = new MySqlParameter();
            parametro2.ParameterName = "@año";
            parametro2.Value = año;

            MySqlParameter parametro3 = new MySqlParameter();
            parametro3.ParameterName = "@Semestre";
            parametro3.Value = Semestre;

            MySqlParameter parametro4 = new MySqlParameter();
            parametro4.ParameterName = "@Trimestre";
            parametro4.Value = Trimestre;

            MySqlParameter parametro5 = new MySqlParameter();
            parametro5.ParameterName = "@mes";
            parametro5.Value = mes;

            MySqlParameter parametro6 = new MySqlParameter();
            parametro6.ParameterName = "@quincena";
            parametro6.Value = quincena;

            MySqlParameter parametro7 = new MySqlParameter();
            parametro7.ParameterName = "@semana";
            parametro7.Value = semana;

            MySqlParameter parametro8 = new MySqlParameter();
            parametro8.ParameterName = "@dia";
            parametro8.Value = dia;

            MySqlParameter parametro9 = new MySqlParameter();
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
    }
}
