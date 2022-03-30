using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class JornadasNegocios
    {
        JornadasDatos objDatos = new JornadasDatos();

        public List<JornadasEntidades> ListarJornadas(string buscar)
        {
            return objDatos.ListarJornadas(buscar);
        }

        public void InsertarJornada(JornadasEntidades Jornada)
        {
            objDatos.InsertarJornada(Jornada);
        }

        public void EditarJornada(JornadasEntidades Jornada)
        {
            objDatos.EditarJornada(Jornada);
        }

        public string RevisarLlegada(JornadasEntidades Jornada)
        {
            return objDatos.RevisarLlegada(Jornada);
        }

        public void InsertarSalida(JornadasEntidades Jornada)
        {
            objDatos.InsertarSalida(Jornada);
        }

        public List<JornadasEntidades> ListarEspecifica(int nomina, int empleado)
        {
            return objDatos.ListarEspecifica(nomina, empleado);
        }

        public DataTable ListarEspecifica(int nomina, string _empleado)
        {
            return objDatos.ListarEspecifica(nomina, _empleado);
        }
    }
}
