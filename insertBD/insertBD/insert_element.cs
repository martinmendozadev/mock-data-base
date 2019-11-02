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
        //Iniciaice las variales globales.
        private int idnum = 0, copiasTiket = 1, inicioBD=0;
        private Random numRan = new Random();
        private ConexionF conexion = new ConexionF();
        private ObVentas ventas = new ObVentas();

        //Método para insertar en la TABLA VENTAS recibe por paramentro el numero de tuplas a insertar.
        public void ejecutar(int a, ProgressBar progreso){
            conexion.abrirConexion();           //Abro la conexion a la BD
            inicioBD = conexion.registros();    //Guardo el inicio de registros
            progreso.Maximum = a;               //Valor maximo de la barra de progreso
            
            for(int index = 0;index < a;index++)
            {
                idnum++;    //Varible útil para ir incrementando el valor de NoTiket

                if ((conexion.registros() - inicioBD) < a)
                {
                    copiasTiket = numeroRandom(1, 10);
                    
                    //Verifico que con el nuevo numero de Tikets sea menor a el numero de tuplas requeridas.
                    if(((conexion.registros() - inicioBD)+copiasTiket)<=a)
                    {
                        //Inserto n Tickets en tabla Ventas
                        for (int i = 0; i < copiasTiket; i++){
                            ventas.refrescar();
                            ventas.setidNum(idnum);
                            conexion.cargaraVentas(ventas.getNoTiket(), ventas.getidTienda(), ventas.getidProducto(), ventas.getcantidad(), ventas.getprecio_venta(), ventas.getidTiempo());

                            //ProgressBar Ingremento
                            progreso.Value++;
                        }
                    }
                }
            }

            //Cierro la conexion a la BD
            conexion.cerrarConexion();

            //Envio mensaje en caso de que todo haya salido bien
            MessageBox.Show(a + " Tuplas Insertadas Correctamente", "Base de Datos");
        }

        private Int32 numeroRandom(int min, int max){
            Int32 rand = numRan.Next(min, max);

            return rand;
        }
    }
}