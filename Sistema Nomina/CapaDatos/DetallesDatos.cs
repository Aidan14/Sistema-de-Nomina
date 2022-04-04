using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DetallesDatos
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

        public List<DetallesEntidades> ListarDetalles(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_Detalle", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<DetallesEntidades> Listar = new List<DetallesEntidades>();

            while (LeerFilas.Read())
            {
                Listar.Add(new DetallesEntidades
                {
                    Nomina = LeerFilas.GetInt32(0),
                    Empleado = LeerFilas.GetInt32(1),
                    Bruto = LeerFilas.GetDouble(2),
                    Horas_Trabajadas = LeerFilas.GetInt32(3),
                    AFP = LeerFilas.GetDouble(4),
                    ARS = LeerFilas.GetDouble(5),
                    ISR = LeerFilas.GetDouble(6),
                    Neto = LeerFilas.GetDouble(7),
                });
            }

            Conexion.Close();
            LeerFilas.Close();

            return Listar;
        }

        public void InsertarDetalle(DetallesEntidades Detalle)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_Detalle", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Nomina", Detalle.Nomina);
            cmd.Parameters.AddWithValue("@ID_Empleado", Detalle.Empleado);
            cmd.Parameters.AddWithValue("@Sueldo_Base", Detalle.Bruto);
            cmd.Parameters.AddWithValue("@Horas_Trabajadas", Detalle.Horas_Trabajadas);
            cmd.Parameters.AddWithValue("@AFP", Detalle.AFP);
            cmd.Parameters.AddWithValue("@ARS", Detalle.ARS);
            cmd.Parameters.AddWithValue("@ISR", Detalle.ISR);
            cmd.Parameters.AddWithValue("@Sueldo_Neto", Detalle.Neto);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EditarDetalle(DetallesEntidades Detalle)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_Detalle", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Nomina", Detalle.Nomina);
            cmd.Parameters.AddWithValue("@ID_Empleado", Detalle.Empleado);
            cmd.Parameters.AddWithValue("@Sueldo_Base", Detalle.Bruto);
            cmd.Parameters.AddWithValue("@Horas_Trabajadas", Detalle.Horas_Trabajadas);
            cmd.Parameters.AddWithValue("@AFP", Detalle.AFP);
            cmd.Parameters.AddWithValue("@ARS", Detalle.ARS);
            cmd.Parameters.AddWithValue("@ISR", Detalle.ISR);
            cmd.Parameters.AddWithValue("@Sueldo_Neto", Detalle.Neto);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public double BrutoPagado()
        {
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(Sueldo_Base),0) FROM Detalles", Conexion);
            Conexion.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            double brutoPagado = dr.GetDouble(0);
            Conexion.Close();
            return brutoPagado;
        }

        public double NetoPagado()
        {
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(Sueldo_Neto),0) FROM Detalles", Conexion);
            Conexion.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            double netoPagado = dr.GetDouble(0);
            Conexion.Close();
            return netoPagado;
        }
    }
}