using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class NominasEntidades
    {
        private int _ID;
        private int _Usuario;
        private DateTime _Fecha;
        private DateTime _Desde;
        private DateTime _Hasta;

        public int ID { get => _ID; set => _ID = value; }
        public int Usuario { get => _Usuario; set => _Usuario = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public DateTime Desde { get => _Desde; set => _Desde = value; }
        public DateTime Hasta { get => _Hasta; set => _Hasta = value; }
    }
}
