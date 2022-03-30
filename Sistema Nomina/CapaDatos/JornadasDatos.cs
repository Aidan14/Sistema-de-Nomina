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
    public class JornadasDatos
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

        public List<JornadasEntidades> ListarJornadas(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_JORNADA", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<JornadasEntidades> Listar = new List<JornadasEntidades>();

            while (LeerFilas.Read())
            {
                Listar.Add(new JornadasEntidades
                {
                    ID = LeerFilas.GetInt32(0),
                    Empleado = LeerFilas.GetInt32(1),
                    Fecha = LeerFilas.GetDateTime(2),
                    Llegada = LeerFilas.GetTimeSpan(3),
                    Salida = LeerFilas.GetTimeSpan(4),
                    Observacion = LeerFilas.GetString(5),
                });
            }

            Conexion.Close();
            LeerFilas.Close();

            return Listar;
        }

        public void InsertarJornada(JornadasEntidades Jornada)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_JORNADA", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Empleado", Jornada.Empleado);
            cmd.Parameters.AddWithValue("@Fecha", Jornada.Fecha);
            cmd.Parameters.AddWithValue("@Hora_Entrada", Jornada.Llegada);
            cmd.Parameters.AddWithValue("@Hora_Salida", Jornada.Salida);
            cmd.Parameters.AddWithValue("@Observacion", Jornada.Observacion);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EditarJornada(JornadasEntidades Jornada)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_JORNADA", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Jornada", Jornada.ID);
            cmd.Parameters.AddWithValue("@ID_Empleado", Jornada.Empleado);
            cmd.Parameters.AddWithValue("@Fecha", Jornada.Fecha);
            cmd.Parameters.AddWithValue("@Hora_Entrada", Jornada.Llegada);
            cmd.Parameters.AddWithValue("@Hora_Salida", Jornada.Salida);
            cmd.Parameters.AddWithValue("@Observacion", Jornada.Observacion);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public string RevisarLlegada(JornadasEntidades Jornada)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Jornadas WHERE Fecha = @Fecha AND ID_Empleado = @ID_Empleado", Conexion);
            Conexion.Open();

            Console.WriteLine("Fecha: " + Convert.ToString(Jornada.Fecha) + "\nEmpleado: " + Convert.ToString(Jornada.Empleado));

            cmd.Parameters.AddWithValue("@Fecha", Jornada.Fecha);
            cmd.Parameters.AddWithValue("@ID_Empleado", Jornada.Empleado);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                if (dr.GetTimeSpan(4) == TimeSpan.Parse("00:00:00"))
                {
                    Conexion.Close();
                    return "llego";
                }
                else
                {
                    Conexion.Close();
                    return "salio";
                }
            }
            else {
                Conexion.Close();
                return "no llego";
            }
        }

        public void InsertarSalida(JornadasEntidades Jornada)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Jornadas SET Hora_Salida = @Salida WHERE ID_Empleado = @ID_Empleado AND Fecha = @Fecha", Conexion);
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Empleado", Jornada.Empleado);
            cmd.Parameters.AddWithValue("@Fecha", Jornada.Fecha);
            cmd.Parameters.AddWithValue("@Salida", Jornada.Salida);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public List<JornadasEntidades> ListarEspecifica(int nomina, int empleado)
        {
            string desde, hasta;

            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SELECT Periodo_Desde, Periodo_Hasta FROM Nominas WHERE ID_Nomina = @ID_Nomina", Conexion);
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Nomina", nomina);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            desde = dr.GetDateTime(0).ToString("MM/dd/yyyy");
            hasta = dr.GetDateTime(1).ToString("MM/dd/yyyy");

            Conexion.Close();

            cmd = new SqlCommand("SELECT * FROM Jornadas WHERE ID_Empleado = @ID_Empleado AND Fecha BETWEEN @Desde AND @Hasta", Conexion);
            Conexion.Open();

            Console.WriteLine("desde: " + hasta);
            cmd.Parameters.AddWithValue("@ID_Empleado", empleado);
            cmd.Parameters.AddWithValue("@Desde", desde);
            cmd.Parameters.AddWithValue("@Hasta", hasta);

            LeerFilas = cmd.ExecuteReader();

            List<JornadasEntidades> Listar = new List<JornadasEntidades>();

            while (LeerFilas.Read())
            {
                Listar.Add(new JornadasEntidades
                {
                    ID = LeerFilas.GetInt32(0),
                    Empleado = LeerFilas.GetInt32(1),
                    Fecha = LeerFilas.GetDateTime(2),
                    Llegada = LeerFilas.GetTimeSpan(3),
                    Salida = LeerFilas.GetTimeSpan(4),
                    Observacion = LeerFilas.GetString(5),
                });
            }

            Conexion.Close();
            LeerFilas.Close();

            return Listar;
        }

        public DataTable ListarEspecifica(int nomina, string _empleado)
        {
            string desde, hasta; int empleado = Convert.ToInt32(_empleado);

            SqlCommand cmd = new SqlCommand("SELECT Periodo_Desde, Periodo_Hasta FROM Nominas WHERE ID_Nomina = @ID_Nomina", Conexion);
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Nomina", nomina);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            desde = dr.GetDateTime(0).ToString("MM/dd/yyyy");
            hasta = dr.GetDateTime(1).ToString("MM/dd/yyyy");

            Conexion.Close();

            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT * FROM Jornadas WHERE ID_Empleado = @ID_Empleado AND Fecha BETWEEN @Desde AND @Hasta", Conexion);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID_Empleado", empleado);
            cmd.Parameters.AddWithValue("@Desde", desde);
            cmd.Parameters.AddWithValue("@Hasta", hasta);

            da.Fill(dt);
            Conexion.Close();

            return dt;
        }
    }
}