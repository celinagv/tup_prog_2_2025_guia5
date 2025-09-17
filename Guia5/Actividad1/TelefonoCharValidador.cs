using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad1
{
    internal class TelefonoCharValidador:Validador
    {

        string MENSAJE_ERROR;
        string MENSAJE_OK;

        public TelefonoCharValidador(string ex) : base(ex)
        {
            MENSAJE_ERROR = "Número de teléfono incorrecto";
            MENSAJE_OK = "Número de teléfono Correcto";
        };
        public override string VerMensaje()
        {
            return base.VerMensaje();
        }

        public override bool Validar()
        {
            return false;
        }
    }
}
