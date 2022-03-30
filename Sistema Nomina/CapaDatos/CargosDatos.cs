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
    public class CargosDatos
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

        public List<CargosEntidades> ListarCargos(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_CARGO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<CargosEntidades> Listar = new List<CargosEntidades>();

            while (LeerFilas.Read())
            {
                Listar.Add(new CargosEntidades
                {
                    ID = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1)
                });
            }

            Conexion.Close();
            LeerFilas.Close();

            return Listar;
        }

        public void InsertarCargo(CargosEntidades Cargo)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_CARGO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre", Cargo.Nombre);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EditarCargo(CargosEntidades Cargo)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_CARGO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Cargo", Cargo.ID);
            cmd.Parameters.AddWithValue("@Nombre", Cargo.Nombre);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }
    }
}