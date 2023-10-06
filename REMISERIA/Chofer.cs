using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REMISERIA
{
    internal class Chofer
    {
        OleDbCommand comando;
        OleDbConnection conector;
        OleDbDataAdapter adaptador;
        DataTable tabla;


        public Chofer()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=REMISYA.mdb");
            comando = new OleDbCommand();
            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Choferes";

            adaptador.Fill(tabla);

            DataColumn[] vec = new DataColumn[1];
            vec[0] = tabla.Columns["chofer"];
            tabla.PrimaryKey = vec;
        }


        //DataRow fila;
        public string buscar(int chofer)
        {
            DataRow fila = tabla.Rows.Find(chofer);
            string nombre = fila["nombre"].ToString();
            return nombre;
        }

        public void modificar(string nombre, int chofer)
        {
            DataRow fila = tabla.Rows.Find(chofer);

            fila["nombre"] = nombre;
            //fila["chofer"] = chofer;

            OleDbCommandBuilder cb = new OleDbCommandBuilder(adaptador);
            adaptador.Update(tabla);
        }

        public void Nombres(string parteNombre, DataGridView grilla)
        {
            foreach (DataRow fila in tabla.Rows)
            {
                if (fila["nombre"].ToString().Contains(parteNombre))
                {
                    grilla.Rows.Add(fila["chofer"], fila["nombre"]);
                }
            }

        }



        public string getNombre(int chofer)
        {
            DataRow fila = tabla.Rows.Find(chofer);
            return fila["nombre"].ToString();
        }

        public DataTable GetData()
        {
            return tabla;
        }


        public int[] Choferes()
        {
            int[] choferes = new int[8];
            int i = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                choferes[i] = int.Parse(fila["chofer"].ToString());
                i++;
            }
            return choferes;
        }
    }
}
