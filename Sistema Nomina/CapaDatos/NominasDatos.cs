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
    public class NominasDatos
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

        public List<NominasEntidades> ListarNominas(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_Nomina", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<NominasEntidades> Listar = new List<NominasEntidades>();

            while (LeerFilas.Read())
            {
                Listar.Add(new NominasEntidades
                {
                    ID = LeerFilas.GetInt32(0),
                    Usuario = LeerFilas.GetInt32(1),
                    Fecha = LeerFilas.GetDateTime(2),
                    Desde = LeerFilas.GetDateTime(3),
                    Hasta = LeerFilas.GetDateTime(4)
                });
            }

            Conexion.Close();
            LeerFilas.Close();

            return Listar;
        }

        public void InsertarNomina(NominasEntidades Nomina)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_Nomina", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Usuario", Nomina.Usuario);
            cmd.Parameters.AddWithValue("@Fecha", Nomina.Fecha);
            cmd.Parameters.AddWithValue("@Periodo_Desde", Nomina.Desde);
            cmd.Parameters.AddWithValue("@Periodo_Hasta", Nomina.Hasta);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EditarNomina(NominasEntidades Nomina)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_Nomina", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Nomina", Nomina.ID);
            cmd.Parameters.AddWithValue("@ID_Usuario", Nomina.Usuario);
            cmd.Parameters.AddWithValue("@Fecha", Nomina.Fecha);
            cmd.Parameters.AddWithValue("@Periodo_Desde", Nomina.Desde);
            cmd.Parameters.AddWithValue("@Periodo_Hasta", Nomina.Hasta);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }
    }
}