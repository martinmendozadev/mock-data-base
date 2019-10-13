using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace insertBD
{
    class insert_element
    {

        //Iniciaice las variales globales, cada tipo de variable corresponde a el tipo de dato de la BD.
        MySqlConnection Conexion = new MySqlConnection("Server=localhost; User id=root; Database=BD_Operacional_Ventas; Password=;");
        String NoTiket = "", idTienda = "", idProducto = "", idnom = "TK";
        int precio_venta = 0, cantidad = 0, idnum = 1;
        DateTime fecha;

        //Arreglos de PKs de las otras tuplas
        String[] idTiendas = { "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10",
                               "T11", "T12", "T13", "T14", "T15", "T16", "T17", "T18", "T19", "T20",
                               "T21", "T22", "T23", "T24", "T25", "T26", "T27", "T28", "T29", "T30",
                               "T31", "T32", "T33", "T34", "T35", "T36", "T37", "T38", "T39", "T40",
                               "T41", "T42", "T43", "T44", "T45"
                             };
        String[] idProductos = { "P1", "P2", "P3", "P4", "P5", "P6", "P7", "P8", "P9", "P10",
                                 "P11", "P12", "P13", "P14", "P15", "P16", "P17", "P18", "P19", "P20",
                                 "P21", "P22", "P23", "P24", "P25", "P26", "P27", "P28", "P29", "P30"};

        //Arreglo de precios
        int[] precios = { };

        //Método para insertar en la TABLA VENTAS recibe por paramentro el numero de tuplas a insertar.
        public void ejecutar(int a, ProgressBar progreso)
        {
            try
            {
                Conexion.Open();        //Abro conexion
                progreso.Minimum = 0;   //Valor minimo de la barra de progreso
                progreso.Maximum = a;   //Valor maximo de la barra de progreso

                for (int i = 0; i < a; i++) //Ciclo para insertar las tuplas.
                {
                    llenadoVariables(); //Le asigno nuevos valores a las variables para después incertarlos.
                    idnum++;            //Varible útil para ir incrementando el valor de NoTiket

                    //Instruccion SQL para insertar en la BD.
                    MySqlCommand comando1 = new MySqlCommand("INSERT INTO ventas values (@NoTiket,@idTienda,@idProducto,@cantidad,@precio_venta,@fecha)");
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
                    parametro6.ParameterName = "@fecha";
                    parametro6.Value = fecha;

                    //Cargo cada valor de los pareametros al comando SQL
                    comando1.Parameters.Add(parametro1);
                    comando1.Parameters.Add(parametro2);
                    comando1.Parameters.Add(parametro3);
                    comando1.Parameters.Add(parametro4);
                    comando1.Parameters.Add(parametro5);
                    comando1.Parameters.Add(parametro6);

                    //Ejecuto la sentencia SQL
                    comando1.ExecuteNonQuery();

                    //ProgressBar Ingremento
                    progreso.Value++;
                }
                //Envio mensaje en caso de que todo haya salido bien
                MessageBox.Show(a + " Tuplas Insertadas Correctamente", "Base de Datos");
                //Cierro la conexion a la BD
                Conexion.Close();

            }
            catch (Exception errr)
            { //En caso de error envio mensaje a la pantalla
                MessageBox.Show("Error en la conexion \n\n" + errr);
            }
        }

        //Metodo que redirecciona la asignacion de variables a submetodos.
        private void llenadoVariables()
        {
            NoTiket = var1();
            idTienda = var2();
            idProducto = var3();
            cantidad = var4();
            precio_venta = var5();
            fecha = var6();
        }

        //Método que genera un numero ranjo entre un intervalo
        private Int32 numeroRandom(int min, int max)
        {
            Random numRan = new Random();

            return numRan.Next(min, max);
        }

        //Metodos para asignar valores a las variables de manera aleatoria pero controlada
        private string var1()
        {
            return NoTiket = idnom + "" + idnum;
        }

        private string var2()
        {
            idTienda = idTiendas[numeroRandom(0, idTiendas.Length)];

            return idTienda;
        }

        private string var3()
        {
            idProducto = idProductos[numeroRandom(0, idProductos.Length)];

            return idProducto;
        }

        private int var4()
        {
            return cantidad = numeroRandom(1, 20);
        }

        private int var5()
        {
            return precio_venta = numeroRandom(1, 1000);
        }

        private DateTime var6()
        {
            Int32 dia = numeroRandom(1, 31);
            Int32 mes = numeroRandom(1, 12);
            Int32 hora = numeroRandom(0, 23);
            Int32 minuto = numeroRandom(0, 60);
            Int32 segundo = numeroRandom(0, 60);

            return new DateTime(2018, mes, dia, hora, minuto, segundo);
        }

    }
}