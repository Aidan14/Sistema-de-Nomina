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
    public class HorariosDatos
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

        public List<HorariosEntidades> ListarHorarios(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_HORARIO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<HorariosEntidades> Listar = new List<HorariosEntidades>();

            while (LeerFilas.Read())
            {
                Listar.Add(new HorariosEntidades
                {
                    ID = LeerFilas.GetInt32(0),
                    Tipo = LeerFilas.GetString(1),
                    Desde = LeerFilas.GetTimeSpan(2),
                    Hasta = LeerFilas.GetTimeSpan(3)
                });
            }

            Conexion.Close();
            LeerFilas.Close();

            return Listar;
        }

        public void InsertarHorario(HorariosEntidades Horario)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_HORARIO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@Tipo", Horario.Tipo);
            cmd.Parameters.AddWithValue("@Desde", Horario.Desde);
            cmd.Parameters.AddWithValue("@Hasta", Horario.Hasta);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EditarHorario(HorariosEntidades Horario)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_HORARIO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Horario", Horario.ID);
            cmd.Parameters.AddWithValue("@Tipo", Horario.Tipo);
            cmd.Parameters.AddWithValue("@Desde", Horario.Desde);
            cmd.Parameters.AddWithValue("@Hasta", Horario.Hasta);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }
    }
}