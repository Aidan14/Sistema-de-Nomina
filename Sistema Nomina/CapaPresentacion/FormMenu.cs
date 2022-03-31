using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using CapaNegocios;
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

            SqlDataReader dr1 = new SqlCommand("SELECT COUNT(ID_Empleado) FROM Empleados", conexion).ExecuteReader();
            while (dr1.Read()) lbEmpleados.Text = dr1.GetInt32(0).ToString();

            conexion.Close(); conexion.Open();

            SqlDataReader dr2 = new SqlCommand("SELECT COUNT(ID_Nomina) FROM Nominas", conexion).ExecuteReader();
            while (dr2.Read()) lbNominas.Text = dr2.GetInt32(0).ToString();


            DetallesNegocios negocios = new DetallesNegocios();
            lbBruto.Text = Convert.ToString(negocios.BrutoPagado());
            lbNeto.Text = Convert.ToString(negocios.NetoPagado());

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

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            barra.Controls.Add(childForm);
            barra.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHorarios());
        }

        private void btnCargos_Click(object sender, EventArgs e)
        {
            openChildForm(new FormCargos());
        }

        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDepartamentos());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUsuarios());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            openChildForm(new FormEmpleados());
        }

        private void btnJornadas_Click(object sender, EventArgs e)
        {
            openChildForm(new FormJornadas());
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            openChildForm(new FormAsistencia());
        }

        private void btnNominas_Click(object sender, EventArgs e)
        {
            openChildForm(new FormNominas());
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDetalles());
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {


        }
    }
}
