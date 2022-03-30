using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class UsuariosEntidades
    {

        private int _ID;
        private string _Nombre;
        private string _Contraseña;
        private string _Rol;

        public int ID { get => _ID; set => _ID = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
        public string Rol { get => _Rol; set => _Rol = value; }
    }
}
