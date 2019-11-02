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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dim_Tiempo a = new Dim_Tiempo();
            this.Hide();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TablaTiempo b = new TablaTiempo();
            this.Hide();
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 c = new Form1();
            this.Hide();
            c.Show();
        }
    }
}
