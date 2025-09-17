using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Actividad3
{
    internal class Vehiculo:IImportable, IComparable<Vehiculo>
    {
        public string Patente;
        private List<Multa> multas = new List<Multa>();
        public int CantidadMultas { get { return multas.Count; } }

        public double ImporteTotal { get; private set; }

        public Vehiculo() { }

        public Vehiculo (string Patente)
        {
            this.Patente = Patente;
        }

        public Multa VerMulta(int inx)
        {
            if (inx >= 0 && inx < multas.Count)
            {
                return multas[inx];
            }
            return null;
        }

        public bool Importar (string xml)
        {
            Regex regex = new Regex(@"[\s]*?<patente>([\w\s]+?)</patente>[\s]*?", RegexOptions.IgnoreCase);
            Match match = regex.Match(xml);
            if (match.Success == false)
                return false;

            Patente = match.Groups[1].Value;

            Multa multa = new Multa();
            AgregarMulta(multa);

            if (multa.Importar(xml) == false) return false;

            ImporteTotal = multa.Importe;

            return true;
        }

        public override string ToString()
        {
            return $"{Patente}- {ImporteTotal}";
        }

        public int CompareTo (Vehiculo v)
        {
            if (v == null)
                return Patente.CompareTo(v.Patente);
            return 0;
        }

        public void AgregarMulta(Multa multa)
        {
            multas.Add(multa);
        }

    }
}
