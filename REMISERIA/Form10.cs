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
    public partial class Form10 : Form
    {
        Chofer oChofer;
        Viajes oViaje;
        DataTable tViaje;
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            Chofer oChofer;
            Viajes oViaje;
            DataTable tViaje;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(dateTimePicker1.Text);
            int[] choferes = oChofer.Choferes();
            int[] chofer = new int[choferes.Length];
            string mensaje;

            int numeroChofer = 0;
            int i = 0;

            while (i < choferes.Length)
            {
                foreach (DataRow fila in tViaje.Rows)
                {
                    if (fecha == Convert.ToDateTime(fila["fecha"]))
                    {
                        if (choferes[i] == int.Parse(fila["chofer"].ToString()))
                        {
                            numeroChofer = -1;
                            break;
                        }
                        else
                        {
                            numeroChofer = choferes[i];
                        }

                    }
                    else
                    {
                        numeroChofer = choferes[i];

                    }
                }
                chofer[i] = numeroChofer;
                i++;
            }
            listBox1.Items.Clear();
            for (int f = 0; f < chofer.Length; f++)
            {
                if (chofer[f] != -1 && chofer[f] != 0)
                {
                    string nombre = oChofer.getNombre(chofer[f]);
                    listBox1.Items.Add(nombre);
                }
            }
        }
    }
}
