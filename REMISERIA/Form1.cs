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
    public partial class Form1 : Form
    {
        Chofer oChofer;
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            oChofer = new Chofer();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int chofer = int.Parse(txtChofer.Text);
            txtNombre.Text = oChofer.buscar(chofer);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int chofer = int.Parse(txtChofer.Text);
            oChofer.modificar(nombre, chofer);
        }
    }
}
