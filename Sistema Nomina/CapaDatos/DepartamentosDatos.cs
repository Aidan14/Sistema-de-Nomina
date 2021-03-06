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

        public List<DepartamentosEntidades> ListarDepartamentos(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_DEPARTAMENTO", Conexion);
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

        public void InsertarDepartamento(DepartamentosEntidades Departamento)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_DEPARTAMENTO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre", Departamento.Nombre);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EditarDepartamento(DepartamentosEntidades Departamento)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_DEPARTAMENTO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Departamento", Departamento.ID);
            cmd.Parameters.AddWithValue("@Nombre", Departamento.Nombre);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }
    }
}