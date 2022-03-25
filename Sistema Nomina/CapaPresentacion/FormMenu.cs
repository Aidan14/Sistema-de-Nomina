using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class FormMenu : Form
    {
        public FormMenu(FormLogin.Datos datos)
        {
            InitializeComponent();
            lbUsuario.Text = datos.nombre;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

            conexion.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(ID_Empleado), COUNT(ID_Nomina) FROM Empleados, Nominas", conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lbEmpleados.Text = dr.GetInt32(0).ToString();
                lbNominas.Text = dr.GetInt32(0).ToString();
            }

            conexion.Close();

        }

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
