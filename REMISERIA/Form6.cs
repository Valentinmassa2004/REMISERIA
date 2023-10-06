using ALUMNO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REMISERIA
{
    public partial class Form6 : Form
    {
        Viajes oViaje;
        Barrios oBarrio;
        DataTable tViajes;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            oViaje = new Viajes();
            oBarrio = new Barrios();
            tViajes = oViaje.GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdbDestino.Checked)
            {
                string opcion = "desdebarrio";
                oViaje.cantidadViajes(dataGridView1, opcion);

            }
            else
            {
                string opcion = "hastabarrio";
                oViaje.cantidadViajes(dataGridView1, opcion);
            }
        }
    }
}
