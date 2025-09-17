using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad1
{
    internal abstract class Validador
    {
        private string expresion;

        public Validador(string ex)
        {
            expresion = ex;
        }

        public virtual string VerMensaje() { return ""; }

        public abstract bool Validar();
    }
}
