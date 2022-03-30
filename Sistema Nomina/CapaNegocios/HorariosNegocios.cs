using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class HorariosNegocios
    {
        HorariosDatos objDatos = new HorariosDatos();

        public List<HorariosEntidades> ListarHorarios(string buscar)
        {
            return objDatos.ListarHorarios(buscar);
        }

        public void InsertarHorario(HorariosEntidades Horario)
        {
            objDatos.InsertarHorario(Horario);
        }

        public void EditarHorario(HorariosEntidades Horario)
        {
            objDatos.EditarHorario(Horario);
        }
    }
}
