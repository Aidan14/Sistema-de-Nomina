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
    public class EmpleadosNegocios
    {
        EmpleadosDatos objDatos = new EmpleadosDatos();

        public List<EmpleadosEntidades> ListarEmpleados(string buscar)
        {
            return objDatos.ListarEmpleados(buscar);
        }

        public void InsertarEmpleado(EmpleadosEntidades Empleado)
        {
            objDatos.InsertarEmpleado(Empleado);
        }

        public void EditarEmpleado(EmpleadosEntidades Empleado)
        {
            objDatos.EditarEmpleado(Empleado);
        }

        public double SueldoEmpleado(int empleado)
        {
            return objDatos.SueldoEmpleado(empleado);
        }

        public DataTable ListarActivos()
        {
            return objDatos.ListarActivos();
        }

        public int HorarioEmpleado(int empleado)
        {
            return objDatos.HorarioEmpleado(empleado);
        }
    }
}
