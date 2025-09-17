using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Actividad3
{
    internal class Multa:IImportable
    {
        public double Importe{ get; set; }
        
        public Multa() { }
        public Multa(double Importe)
        {
            this.Importe = Importe; 
        }

        public bool Importar(string xml)
        {
            Regex regex = new Regex(@"[\S\s]*?<importe>([\w\s,]+?)</importe>[\S\s]*?", RegexOptions.IgnoreCase);
            Match match = regex.Match(xml);
            if (match.Success == false)
                return false;

            Importe = Convert.ToDouble(match.Groups[1].Value);

            return true;
        }

        public override string ToString()
        {
            return "";
        }

    
    } 

}
