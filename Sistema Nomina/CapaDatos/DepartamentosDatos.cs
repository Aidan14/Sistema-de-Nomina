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
    public class DepartamentosDatos
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

        public List<DepartamentosEntidades> ListarCiudades(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_CIUDADES", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<DepartamentosEntidades> Listar = new List<DepartamentosEntidades>();

            while (LeerFilas.Read())
            {
                Listar.Add(new DepartamentosEntidades
                {
                    ID = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1)
                });
            }

            Conexion.Close();
            LeerFilas.Close();

            return Listar;
        }

        public void InsertarCiudad(DepartamentosEntidades Ciudad)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_CIUDADES", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre", Ciudad.Nombre);
            //cmd.Parameters.AddWithValue("@Region", Ciudad.Region);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        /*public void EditarCiudad(CiudadesEntidades Ciudad)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_CIUDADES", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@Cod_Ciudad", Ciudad.Codigo);
            cmd.Parameters.AddWithValue("@Nombre", Ciudad.Nombre);
            cmd.Parameters.AddWithValue("@Region", Ciudad.Region);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EliminarCiudad(CiudadesEntidades Ciudad)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_CIUDADES", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@Cod_Ciudad", Ciudad.Codigo);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }*/
    }
}