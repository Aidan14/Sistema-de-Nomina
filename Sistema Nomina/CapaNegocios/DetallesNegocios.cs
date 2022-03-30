using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class DetallesNegocios
    {
        DetallesDatos objDatos = new DetallesDatos();

        public List<DetallesEntidades> ListarDetalles(string buscar)
        {
            return objDatos.ListarDetalles(buscar);
        }

        public void InsertarDetalle(DetallesEntidades Detalle)
        {
            objDatos.InsertarDetalle(Detalle);
        }

        public void EditarDetalle(DetallesEntidades Detalle)
        {
            objDatos.EditarDetalle(Detalle);
        }

        public double BrutoPagado()
        {
            return objDatos.BrutoPagado();
        }

        public double NetoPagado()
        {
            return objDatos.NetoPagado();
        }
    }
}
