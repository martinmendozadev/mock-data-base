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

            try
            {
                Int32 a = Convert.ToInt32(textBox1.Text);
                insert_element insertar = new insert_element();
                progreso.Visible = true;
                label3.Text = "Insertando...";
                insertar.ejecutar(a, progreso);
                progreso.Value = 0;
                progreso.Visible = false;
                label3.Text = "";
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nIngresa un número entero.");
                textBox1.Text = "";
            }

            button1.Enabled = true;
        }
    }
}
