using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insertBD
{
    class Tiempo
    {
        private String idTiempo="TM";
        private DateTime fecha = new DateTime();
        private ConexionF conexion = new ConexionF();

        public void GenerarFecha(ProgressBar progreso){
            progreso.Maximum = 365;               //Valor maximo de la barra de progreso
            conexion.abrirConexion();
            for (int id = 0; id < 365; id++)
            {
                conexion.cargaraTiempo((idTiempo+""+(id+1)),fecha);

                //ProgressBar Ingremento
                progreso.Value++;
            }
            conexion.cerrarConexion();
        }
    }
}