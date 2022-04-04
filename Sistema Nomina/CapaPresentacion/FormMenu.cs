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
        FormLogin.Datos datos;

        public FormMenu(FormLogin.Datos _datos)
        {
            InitializeComponent();
            datos = _datos;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            lbUsuario.Text = datos.nombre;
            lbRol.Text = datos.rol;
            CalcularPaneles();
        }

        private void CalcularPaneles()
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

            conexion.Open();

            SqlDataReader dr1 = new SqlCommand("SELECT COUNT(ID_Empleado) FROM Empleados", conexion).ExecuteReader();
            while (dr1.Read()) lbEmpleados.Text = dr1.GetInt32(0).ToString();

            conexion.Close(); conexion.Open();

            SqlDataReader dr2 = new SqlCommand("SELECT COUNT(ID_Nomina) FROM Nominas", conexion).ExecuteReader();
            while (dr2.Read()) lbNominas.Text = dr2.GetInt32(0).ToString();


            DetallesNegocios negocios = new DetallesNegocios();
            lbBruto.Text = Convert.ToString(Math.Round(negocios.BrutoPagado()));
            lbNeto.Text = Convert.ToString(Math.Round(negocios.NetoPagado()));

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
        private void openChildForm(Form childForm, Button _activeButton)
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

        private void btnTab_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "Horarios": openChildForm(new FormHorarios(), btn); break;
                case "Cargos": openChildForm(new FormCargos(), btn); break;
                case "Departamentos": openChildForm(new FormDepartamentos(), btn); break;
                case "Usuarios": openChildForm(new FormUsuarios(), btn); break;
                case "Empleados": openChildForm(new FormEmpleados(), btn); break;
                case "Jornadas": openChildForm(new FormJornadas(), btn); break;
                case "Asistencia": openChildForm(new FormAsistencia(), btn); break;
                case "Nominas": openChildForm(new FormNominas(), btn); break;
                case "Detalles": openChildForm(new FormDetalles(), btn); break;
                case "Configuracion": break;

                default:
                    if (activeForm != null)
                    {
                        activeForm.Close();
                        activeForm = null;
                        CalcularPaneles();

                    }; break;
            }
        }
    }
}
