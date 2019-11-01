using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace insertBD
{
    class ConexionF
    {
        //Iniciaice variables para la BD.
        MySqlConnection Conexion;

        public ConexionF(){
            Conexion = new MySqlConnection("Server=localhost; User id=root; Database=BD_Operacional_Ventas; Password=;");
        }

        public void abrirConexion(){
            try{
                Conexion.Open();        //Abro conexion

            }catch(Exception ex){
                MessageBox.Show("Revise la conexion a la BD\n\n"+ex.Message);
            }
        }

        public void cerrarConexion()
        {
            try{
                Conexion.Close();        //Cierro conexion
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cerrar la conexion a la BD\n\n" + ex.Message);
            }
        }

        public void cargaraVentas(String NoTiket, String idTienda, String idProducto, int cantidad, int precio_venta, DateTime idTiempo)
        {
            //Instruccion SQL para insertar en la BD.
            MySqlCommand comando1 = new MySqlCommand("INSERT INTO ventas values (@NoTiket,@idTienda,@idProducto,@cantidad,@precio_venta,@idTiempo)");
            //Cargo mi instruccion SQL a Conexion.
            comando1.Connection = Conexion;

            //Asigno valores a los paremetros de la sentencia SQL
            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@NoTiket";
            parametro1.Value = NoTiket;

            MySqlParameter parametro2 = new MySqlParameter();
            parametro2.ParameterName = "@idTienda";
            parametro2.Value = idTienda;

            MySqlParameter parametro3 = new MySqlParameter();
            parametro3.ParameterName = "@idProducto";
            parametro3.Value = idProducto;

            MySqlParameter parametro4 = new MySqlParameter();
            parametro4.ParameterName = "@cantidad";
            parametro4.Value = cantidad;

            MySqlParameter parametro5 = new MySqlParameter();
            parametro5.ParameterName = "@precio_venta";
            parametro5.Value = precio_venta;

            MySqlParameter parametro6 = new MySqlParameter();
            parametro6.ParameterName = "@idTiempo";
            parametro6.Value = idTiempo;

            //Cargo cada valor de los pareametros al comando SQL
            comando1.Parameters.Add(parametro1);
            comando1.Parameters.Add(parametro2);
            comando1.Parameters.Add(parametro3);
            comando1.Parameters.Add(parametro4);
            comando1.Parameters.Add(parametro5);
            comando1.Parameters.Add(parametro6);

            //Ejecuto la sentencia SQL
            comando1.ExecuteNonQuery();
        }

    }
}