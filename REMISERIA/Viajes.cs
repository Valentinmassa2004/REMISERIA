using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ALUMNO;

namespace REMISERIA
{
    internal class Viajes
    {
        OleDbCommand comando;
        OleDbConnection conector;
        OleDbDataAdapter adaptador;
        DataTable tabla;

        public Viajes()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=REMISYA.mdb");
            comando = new OleDbCommand();
            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Viajes";

            adaptador.Fill(tabla);

            DataColumn[] vec = new DataColumn[1];
            vec[0] = tabla.Columns["viaje"];
            tabla.PrimaryKey = vec;
        }

        Chofer oChofer;


        public DataTable GetData()
        {
            return tabla;
        }

        Barrios oBarrio;

        public void cantidadViajes(DataGridView grilla, string opcion)
        {
            oBarrio = new Barrios();

            int i = 0, cantidad = 0, f = 0;
            DataRow fila = tabla.Rows[0];
            string nombre = "";

            grilla.Rows.Clear();
            while (i < 11)
            {
                int[] Barrios = oBarrio.devolverBarrio();
                int auxBarrios = Barrios[i];
                foreach (DataRow datos in tabla.Rows)
                {

                    if (auxBarrios == int.Parse(datos[$"{opcion}"].ToString()))
                    {
                        nombre = oBarrio.nombreBarrio(auxBarrios);
                        cantidad++;
                    }

                }

                grilla.Rows.Add(nombre, cantidad);
                i++;
                cantidad = 0;


            }
        }


        public void eliminarViaje(int viaje)
        {
            DataRow fila = tabla.Rows.Find(viaje);

            //tabla.Rows.Remove(fila);
            int indice = tabla.Rows.IndexOf(fila);
            tabla.Rows.RemoveAt(indice);

            OleDbCommandBuilder cb = new OleDbCommandBuilder(adaptador);
            adaptador.Update(tabla);

        }
    }
}
