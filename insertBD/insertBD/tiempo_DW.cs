using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insertBD
{
    class tiempo_DW
    {
        private String idTiempo = "TM";
        private Int32 num = 0, Semestre=1, Trimestre=1, quincena=1, quincenaAux=1, semanaAux=1, semana=1, diaC=1;
        private DateTime fecha = new DateTime();
        private ConexionDW2 conexion = new ConexionDW2();

        public void GenerarFecha(ProgressBar progreso)
        {
            progreso.Maximum = 376;     //Valor maximo de la barra de progreso
            conexion.Abrir();   //Abro la conexion de la BD

            for (Int32 mes = 1; mes < 13; mes++)
            {
                if (mes == 3 || mes==9)
                {
                    Trimestre++;
                }
                if (mes == 6)
                {
                    Semestre = 2;
                    Trimestre++;
                }

                for (Int32 dia = 1; dia < 32; dia++)
                {
                    semanaAux++;
                    quincenaAux++;

                    if(semanaAux==7){
                        semana++;
                        semanaAux = 0;
                    }
                    if (quincenaAux == 15)
                    {
                        quincena++;
                        quincenaAux = 0;
                    }

                    for (Int32 hora = 0; hora < 24; hora++)
                    {
                        if (mes == 2)
                        {
                            if (dia < 29)
                            {
                                num++;
                                fecha = new DateTime(2018, mes, dia, hora, 0, 0);
                                conexion.cargaraTiempo((idTiempo + "" + num), 2018, Semestre, Trimestre, mes, quincena, semana, diaC, fecha);
                            }
                        }
                        else if (mes % 2 == 0)
                        {
                            if (dia < 31)
                            {
                                num++;
                                fecha = new DateTime(2018, mes, dia, hora, 0, 0);
                                conexion.cargaraTiempo((idTiempo + "" + num), 2018, Semestre, Trimestre, mes, quincena, semana, diaC, fecha);
                            }
                        }
                        else if (mes % 2 == 1)
                        {
                            if (mes != 9 && mes != 11)
                            {
                                num++;
                                fecha = new DateTime(2018, mes, dia, hora, 0, 0);
                                conexion.cargaraTiempo((idTiempo + "" + num),2018, Semestre, Trimestre, mes, quincena, semana, diaC, fecha);
                            }
                            else if (dia < 31)
                            {
                                num++;
                                fecha = new DateTime(2018, mes, dia, hora, 0, 0);
                                conexion.cargaraTiempo((idTiempo + "" + num),2018, Semestre, Trimestre, mes, quincena, semana, diaC, fecha);

                            }
                        }
                    }

                    //ProgressBar Ingremento
                    progreso.Value++;
                    diaC++;
                }

            }
            conexion.Cerrar();
        }
    }
}
