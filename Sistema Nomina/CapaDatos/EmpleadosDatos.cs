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
    public class EmpleadosDatos
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

        public List<EmpleadosEntidades> ListarEmpleados(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_EMPLEADO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<EmpleadosEntidades> Listar = new List<EmpleadosEntidades>();

            while (LeerFilas.Read())
            {
                Listar.Add(new EmpleadosEntidades
                {
                    ID = LeerFilas.GetInt32(0),
                    Cedula = LeerFilas.GetString(1),
                    Nombre = LeerFilas.GetString(2),
                    Fecha_Nacimiento = LeerFilas.GetDateTime(3),
                    Departamento = LeerFilas.GetInt32(4),
                    Cargo = LeerFilas.GetInt32(5),
                    Horario = LeerFilas.GetInt32(6),
                    Sexo = Convert.ToChar(LeerFilas.GetValue(7)),
                    Telefono = LeerFilas.GetString(8),
                    Direccion = LeerFilas.GetString(9),
                    Estado = LeerFilas.GetString(10),
                    Pago_Hora = LeerFilas.GetDouble(11)
                });
            }

            Conexion.Close();
            LeerFilas.Close();

            return Listar;
        }

        public void InsertarEmpleado(EmpleadosEntidades Empleado)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_EMPLEADO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@Cedula", Empleado.Cedula);
            cmd.Parameters.AddWithValue("@Nombre", Empleado.Nombre);
            cmd.Parameters.AddWithValue("@Fecha_Nacimiento", Empleado.Fecha_Nacimiento);
            cmd.Parameters.AddWithValue("@ID_Departamento", Empleado.Departamento);
            cmd.Parameters.AddWithValue("@ID_Cargo", Empleado.Cargo);
            cmd.Parameters.AddWithValue("@ID_Horario", Empleado.Horario);
            cmd.Parameters.AddWithValue("@Sexo", Empleado.Sexo);
            cmd.Parameters.AddWithValue("@Telefono", Empleado.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", Empleado.Direccion);
            cmd.Parameters.AddWithValue("@Estado", Empleado.Estado);
            cmd.Parameters.AddWithValue("@Pago_Hora", Empleado.Pago_Hora);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EditarEmpleado(EmpleadosEntidades Empleado)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_EMPLEADO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Empleado", Empleado.ID);
            cmd.Parameters.AddWithValue("@Cedula", Empleado.Cedula);
            cmd.Parameters.AddWithValue("@Nombre", Empleado.Nombre);
            cmd.Parameters.AddWithValue("@Fecha_Nacimiento", Empleado.Fecha_Nacimiento);
            cmd.Parameters.AddWithValue("@ID_Departamento", Empleado.Departamento);
            cmd.Parameters.AddWithValue("@ID_Cargo", Empleado.Cargo);
            cmd.Parameters.AddWithValue("@ID_Horario", Empleado.Horario);
            cmd.Parameters.AddWithValue("@Sexo", Empleado.Sexo);
            cmd.Parameters.AddWithValue("@Telefono", Empleado.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", Empleado.Direccion);
            cmd.Parameters.AddWithValue("@Estado", Empleado.Estado);
            cmd.Parameters.AddWithValue("@Pago_Hora", Empleado.Pago_Hora);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public double SueldoEmpleado(int empleado)
        {
            SqlCommand cmd = new SqlCommand("SELECT Pago_Hora FROM Empleados WHERE ID_Empleado = @ID_Empleado", Conexion);
            Conexion.Open();

            cmd.Parameters.AddWithValue("ID_Empleado", empleado);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            double pago = dr.GetDouble(0);

            Conexion.Close();
            return pago;
        }

        public DataTable ListarActivos()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Empleado, Pago_Hora FROM Empleados WHERE Estado = 'Activo'", Conexion);
            Conexion.Open();

            da.Fill(dt);

            Conexion.Close();

            return dt;
        }

        public int HorarioEmpleado(int empleado)
        {
            SqlCommand cmd = new SqlCommand("SELECT ID_Horario FROM Empleados WHERE ID_Empleado = @ID_Empleado", Conexion);
            Conexion.Open();

            cmd.Parameters.AddWithValue("ID_Empleado", empleado);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int horario = dr.GetInt32(0);

            Conexion.Close();
            return horario;
        }
    }
}