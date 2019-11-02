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
        private Int32 num = 0;
        private DateTime fecha = new DateTime();
        private ConexionF conexion = new ConexionF();

        public void GenerarFecha(ProgressBar progreso){
            progreso.Maximum = 376;     //Valor maximo de la barra de progreso
            conexion.abrirConexion();   //Abro la conexion de la BD

            for (Int32 mes = 1; mes < 13; mes++)
            {
                //MessageBox.Show("Mes: "+mes+"\nResiduo del Mes:"+(mes%2));
                for (Int32 dia = 1; dia < 32; dia++)
                {
                    for (Int32 hora = 0; hora < 24; hora++)
                    {
                        if(mes==2){
                            if (dia < 29)
                            {
                                num++;
                                fecha = new DateTime(2018, mes, dia, hora, 0, 0);
                                conexion.cargaraTiempo((idTiempo + "" + num), fecha);
                            }
                        }else if(mes%2==0){
                            if(dia<31){
                                num++;
                                fecha = new DateTime(2018, mes, dia, hora, 0, 0);
                                conexion.cargaraTiempo((idTiempo + "" + num), fecha);
                            }
                        }else if(mes%2==1){
                            if (mes != 9 && mes!=11)
                            {
                                num++;
                                fecha = new DateTime(2018, mes, dia, hora, 0, 0);
                                conexion.cargaraTiempo((idTiempo + "" + num), fecha);
                            }
                            else if(dia<31)
                            {
                                num++;
                                fecha = new DateTime(2018, mes, dia, hora, 0, 0);
                                conexion.cargaraTiempo((idTiempo + "" + num), fecha);
                               
                            }
                        }else{
                            MessageBox.Show("Mes sin incerciones: "+mes);
                        }
                    }

                    //ProgressBar Ingremento
                    progreso.Value++;
                }

            }
            conexion.cerrarConexion();
        }
    }
}