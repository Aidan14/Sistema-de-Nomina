using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class DepartamentosNegocios
    {
        DepartamentosDatos objDatos = new DepartamentosDatos();

        public List<DepartamentosEntidades> ListarDepartamentos(string buscar)
        {
            return objDatos.ListarDepartamentos(buscar);
        }

        public void InsertarDepartamento(DepartamentosEntidades Departamento)
        {
            objDatos.InsertarDepartamento(Departamento);
        }

        public void EditarDepartamento(DepartamentosEntidades Departamento)
        {
            objDatos.EditarDepartamento(Departamento);
        }
    }
}
