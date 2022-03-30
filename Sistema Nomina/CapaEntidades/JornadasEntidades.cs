using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class JornadasEntidades
    {
        private int _ID;
        private int _Empleado;
        private DateTime _Fecha;
        private TimeSpan _Llegada;
        private TimeSpan _Salida;
        private string _Observacion;

        public int ID { get => _ID; set => _ID = value; }
        public int Empleado { get => _Empleado; set => _Empleado = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public TimeSpan Llegada { get => _Llegada; set => _Llegada = value; }
        public TimeSpan Salida { get => _Salida; set => _Salida = value; }
        public string Observacion { get => _Observacion; set => _Observacion = value; }
    }
}
