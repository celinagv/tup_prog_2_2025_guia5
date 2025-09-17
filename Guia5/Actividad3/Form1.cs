using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Vehiculo> vehiculos = new List<Vehiculo>();
        private void button1_Click(object sender, EventArgs e)
        {
            

            string texto = textBox1.Text;

            Regex regex = new Regex(@"<multa>[\s\S]*?</multa>", RegexOptions.IgnoreCase);
            //RegexOptions.IgnoreCase:no diferencia mayúsculas y minúsculas.
            //[\s\S]*?: espacios en blanco , muchas veces, pero que no tome todo. entre multa y ,/multa
            Match match = regex.Match(texto);// busca las concidencias en el texto

            while (match.Success)
            {
                string objectXML = match.Value; //si encuentra copia el texto obtenido

                Vehiculo nuevo = new Vehiculo();
                if (nuevo.Importar(objectXML)) //al vehiculo le incluye la multa
                {
                    vehiculos.Sort();
                    int idx = vehiculos.BinarySearch(nuevo);// busca el vehiculo creado en la lista 
                    if (idx > -1)
                    {
                        //vehiculos[idx].AgregarMulta(nuevo.VerMulta(0)); Agrega la multa
                        for (int n = 0; n < nuevo.CantidadMultas; n++)
                            vehiculos[idx].AgregarMulta(nuevo.VerMulta(n));
                    }
                    else
                    {
                        vehiculos.Add(nuevo);
                    }
                }

                match = match.NextMatch();// Match.success mientras haya otro multa/multa el ciclo continua, nextMatch.
            }

           
        }



        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Vehiculo v in vehiculos)
            {
                listBox1.Items.Add(v.ToString().Trim());
            }

        }
    }
}
