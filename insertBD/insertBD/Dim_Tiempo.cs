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
    public partial class Dim_Tiempo : Form
    {
        public Dim_Tiempo()
        {
            InitializeComponent();
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
                btn_generar.Visible = false;
                label2.Visible = true;
                progreso.Visible = true;
                tiempo_DW tiempoDW = new tiempo_DW();
                progreso.Value = 0;
                tiempoDW.GenerarFecha(progreso);
                MessageBox.Show("Dim Tiempo Generada Correctamente", "Fechas");
                label2.Text = "Dim Tiempo Generada correctamente";
                progreso.Visible = false;
            
        }
    }
}
