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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            //Leeo el  valor de el textbox y lo trato de convertit a INT
            try
            {
                Int32 a = Convert.ToInt32(textBox1.Text);
               
                progreso.Visible = true;        //En caso de poder parsear el valor del textbox inicia el progreso
                button2.Visible = false;
                label3.Text = "Insertando...";
                insert_element insertar = new insert_element();
                insertar.ejecutar(a, progreso); //Inicio el progreso de Instertar tuplas
                progreso.Value = 0;             //Reseteo el progresbar
                progreso.Visible = false;       //Al final de incertar oculto nuevamente el progresbar
                label3.Text = "";               //Limpio los campos  
                textBox1.Text = "";
                button2.Visible = true;
            }
            catch (Exception ex)
            {
                //En caso de error lo imprimo en pantlla
                MessageBox.Show(ex.Message + "\n\nIngresa un número entero.");
                textBox1.Text = "";
            }

            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu a = new menu();
            this.Hide();
            a.Show();
        }
    }
}
