using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> apellidos = new List<string> { "Hernandez", "Saavedra", "Acosta", "Jacob", "Heinze", "Fischer", "Campos" };
        List<string> nombres = new List<string> { "Adriana", "Elizabet", "José", "María", "Ernesto", "Sebastian", "Julio", "Ester", "Ariel", "Betiana", "Silvina", "Ana", "Leandro", "Ayelen", "Daniela", "Miguel" };
        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder listado = new StringBuilder();
            Random r = new Random();
            for (int i=0; i<10; i++)
            {
                int posA = r.Next(0, apellidos.Count);
                int posN = r.Next(0, nombres.Count);
                //listBox1.Items.Add(apellidos[posA] + " " + nombres[posN]);

                listado.AppendLine($"{apellidos[posA]}, {nombres[posN]}");
            }
            listBox1.Items.Add(listado);//tiene que ser un text box para agregar string en listados, listbox solo linea a linea
;        }
    }
}
