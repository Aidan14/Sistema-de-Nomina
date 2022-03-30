using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class NominasNegocios
    {
        NominasDatos objDatos = new NominasDatos();

        public List<NominasEntidades> ListarNominas(string buscar)
        {
            return objDatos.ListarNominas(buscar);
        }

        public void InsertarNomina(NominasEntidades Nomina)
        {
            objDatos.InsertarNomina(Nomina);
        }

        public void EditarNomina(NominasEntidades Nomina)
        {
            objDatos.EditarNomina(Nomina);
        }
    }
}
