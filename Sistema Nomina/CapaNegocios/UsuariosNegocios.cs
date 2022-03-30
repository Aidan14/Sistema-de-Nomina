using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class UsuariosNegocios
    {
        UsuariosDatos objDatos = new UsuariosDatos();

        public List<UsuariosEntidades> ListarUsuarios(string buscar)
        {
            return objDatos.ListarUsuarios(buscar);
        }

        public void InsertarUsuario(UsuariosEntidades Usuario)
        {
            objDatos.InsertarUsuario(Usuario);
        }

        public void EditarUsuario(UsuariosEntidades Usuario)
        {
            objDatos.EditarUsuario(Usuario);
        }
    }
}
