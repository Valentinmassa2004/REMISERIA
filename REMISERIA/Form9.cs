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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        Viajes oViaje;
        Chofer oChofer;
        DataTable tViaje;
        private void Form9_Load(object sender, EventArgs e)
        {

            int cantidadViajes = 0;
            //string fecha = "";
            oViaje = new Viajes();
            tViaje = oViaje.GetData();

            foreach (DataRow fila in tViaje.Rows)
            {
                cantidadViajes++;
            }

            DateTime auxFecha = Convert.ToDateTime(tViaje.Rows[0]["fecha"].ToString());
            int indice;
            string[] fecha = new string[42];
            for (int i = 0; i < cantidadViajes; i++)
            {
                foreach (DataRow datos in tViaje.Rows)
                {
                    fecha[i] = null;
                    if (auxFecha == Convert.ToDateTime(datos["fecha"]))
                    {
                        fecha[i] = datos["fecha"].ToString();

                    }
                    else
                    {
                        fecha[i] = null;
                    }

                }

            }
            for (int i = 0; i < fecha.Length; i++)
            {
                if (fecha[i] != null)
                {
                    comboBox1.Items.Add(fecha[i]);

                }
            }

        }
    }
}
