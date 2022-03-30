using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class CargosNegocios
    {
        CargosDatos objDatos = new CargosDatos();

        public List<CargosEntidades> ListarCargos(string buscar)
        {
            return objDatos.ListarCargos(buscar);
        }

        public void InsertarCargo(CargosEntidades Cargo)
        {
            objDatos.InsertarCargo(Cargo);
        }

        public void EditarCargo(CargosEntidades Cargo)
        {
            objDatos.EditarCargo(Cargo);
        }
    }
}
