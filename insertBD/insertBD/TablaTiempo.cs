using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insertBD
{
    public partial class TablaTiempo : Form
    {
        public TablaTiempo()
        {
            InitializeComponent();
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            ConexionF conexion2=new ConexionF();
            conexion2.abrirConexion();
            if(conexion2.registrosTiempo()<1){
                btn_generar.Visible = false;
                button1.Visible = false;
                label2.Visible=true;
                progreso.Visible=true;
                Tiempo TablaTiempo = new Tiempo();
                progreso.Value = 0;
                TablaTiempo.GenerarFecha(progreso);
                MessageBox.Show("Tabla Tiempo Generada Correctamente","Generando Fechas");
                label2.Text = "Tabla Tiempo Generada";
                progreso.Visible = false;
                button1.Visible = true;
            }else{
                MessageBox.Show("La tabla Tiempo ya está Generada");
            }
            conexion2.cerrarConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu a = new menu();
            this.Hide();
            a.Show();
        }
    }
}
