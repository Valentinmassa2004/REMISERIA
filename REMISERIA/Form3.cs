using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace REMISERIA
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Viajes oViaje;
        DataTable tViaje;
        Chofer oChofer;
        private void Form3_Load(object sender, EventArgs e)
        {
            oViaje = new Viajes();
            oChofer = new Chofer();
            tViaje = oViaje.GetData();

            int i = 0;
            decimal totalRecaudado = 0;

            string nombre = "";

            //dataGridView1.Rows.Clear();
            while (i < 8)
            {
                int[] choferes = oChofer.Choferes();
                int auxChofer = choferes[i];
                foreach (DataRow datos in tViaje.Rows)
                {

                    if (auxChofer == int.Parse(datos["chofer"].ToString()))
                    {
                        nombre = oChofer.getNombre(auxChofer);
                        totalRecaudado += Convert.ToDecimal(datos["importe"].ToString());
                    }
                    else
                    {
                        nombre = oChofer.getNombre(auxChofer);

                    }

                }

                dataGridView1.Rows.Add(nombre, totalRecaudado);
                i++;
                totalRecaudado = 0;


            }
        }
    }
}
