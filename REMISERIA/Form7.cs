using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REMISERIA
{
    public partial class Form7 : Form
    {
        Viajes oViaje;
        DataTable tViaje;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            oViaje = new Viajes();
            tViaje = oViaje.GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int viaje = int.Parse(textBox1.Text);
                DataRow fila = tViaje.Rows.Find(viaje);
                if (fila != null)
                {
                    DateTime fecha = Convert.ToDateTime(fila["fecha"].ToString());
                    dateTimePicker1.Value = fecha;
                    textBox2.Text = fila["km"].ToString();
                    textBox3.Text = fila["importe"].ToString();
                }
                else
                {
                    MessageBox.Show("El viaje no existe", "Aviso");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un numero entero", "Aviso");
                //throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int viaje = int.Parse(textBox1.Text);

            oViaje.eliminarViaje(viaje);
        }
    }
}
