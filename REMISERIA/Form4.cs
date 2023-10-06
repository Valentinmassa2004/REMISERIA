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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        Viajes viaje;
        DataTable tViajes;
        Chofer oChofer;

        private void button1_Click(object sender, EventArgs e)
        {
            Grilla.Rows.Clear();
            DateTime desde = Convert.ToDateTime(dtpDesde.Text);
            DateTime hasta = Convert.ToDateTime(dtpHasta.Text);

            foreach (DataRow datos in tViajes.Rows)
            {
                if (Convert.ToDateTime(datos["fecha"]) >= desde && Convert.ToDateTime(datos["fecha"]) <= hasta)
                {
                    string chofer = oChofer.getNombre(int.Parse(datos["chofer"].ToString()));
                    DateTime fecha = Convert.ToDateTime(datos["fecha"]);
                    Grilla.Rows.Add(datos["viaje"], fecha.ToString("dd/MM/yyyy"), chofer, datos["importe"]);
                }
            }
        }

    }
}
