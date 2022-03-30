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
    public class UsuariosDatos
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

        public List<UsuariosEntidades> ListarUsuarios(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_USUARIO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<UsuariosEntidades> Listar = new List<UsuariosEntidades>();

            while (LeerFilas.Read())
            {
                Listar.Add(new UsuariosEntidades
                {
                    ID = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1),
                    Contraseña = LeerFilas.GetString(2),
                    Rol = LeerFilas.GetString(3)
                });
            }

            Conexion.Close();
            LeerFilas.Close();

            return Listar;
        }

        public void InsertarUsuario(UsuariosEntidades Usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_USUARIO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre", Usuario.Nombre);
            cmd.Parameters.AddWithValue("@Contraseña", Usuario.Contraseña);
            cmd.Parameters.AddWithValue("@Rol", Usuario.Rol);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EditarUsuario(UsuariosEntidades Usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_USUARIO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Usuario", Usuario.ID);
            cmd.Parameters.AddWithValue("@Nombre", Usuario.Nombre);
            cmd.Parameters.AddWithValue("@Contraseña", Usuario.Contraseña);
            cmd.Parameters.AddWithValue("@Rol", Usuario.Rol);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }
    }
}