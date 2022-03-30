using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class HorariosEntidades
    {
        private int _ID;
        private string _Tipo;
        private TimeSpan _Desde;
        private TimeSpan _Hasta;

        public int ID { get => _ID; set => _ID = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }
        public TimeSpan Desde { get => _Desde; set => _Desde = value; }
        public TimeSpan Hasta { get => _Hasta; set => _Hasta = value; }
    }
}
