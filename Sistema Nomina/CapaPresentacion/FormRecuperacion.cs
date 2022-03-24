using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormRecuperacion : Form
    {
        public FormRecuperacion()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnEfectuar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

            conexion.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE Nombre = @Usuario AND Clave = @Clave AND Rol = 'Admin'", conexion);
            cmd.Parameters.AddWithValue("@Usuario", txtAdmin.Text);
            cmd.Parameters.AddWithValue("@Clave", txtClaveAdmin.Text);

            SqlCommand cmd2 = new SqlCommand("UPDATE Usuarios SET Clave = @Clave WHERE Nombre = @Usuario", conexion);
            cmd2.Parameters.AddWithValue("@Clave", txtClaveUsuario.Text);
            cmd2.Parameters.AddWithValue("@Usuario", txtUsuario.Text);

            if (cmd.ExecuteReader().HasRows && txtClaveUsuario.Text == txtConfirmacion.Text)
            {
                conexion.Close();
                conexion.Open();

                cmd2.ExecuteNonQuery();
                MessageBox.Show("Su contraseña ha sido restablecida");
                this.Close();
            }
            else MessageBox.Show("Las credenciales son erroneas");

            conexion.Close();
        }

        private void txtAdmin_Enter(object sender, EventArgs e)
        {
            if (txtAdmin.Text == "Admin") txtAdmin.Text = "";
        }

        private void txtAdmin_Leave(object sender, EventArgs e)
        {
            if (txtAdmin.Text == "") txtAdmin.Text = "Admin";
        }

        private void txtClaveAdmin_Enter(object sender, EventArgs e)
        {
            if (txtClaveAdmin.Text == "Contraseña") txtClaveAdmin.Text = "";
        }

        private void txtClaveAdmin_Leave(object sender, EventArgs e)
        {
            if (txtClaveAdmin.Text == "") txtClaveAdmin.Text = "Contraseña";
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario") txtUsuario.Text = "";
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "") txtUsuario.Text = "Usuario";
        }

        private void txtClaveUsuario_Enter(object sender, EventArgs e)
        {
            if (txtClaveUsuario.Text == "Contraseña Nueva") txtClaveUsuario.Text = "";
        }

        private void txtClaveUsuario_Leave(object sender, EventArgs e)
        {
            if (txtClaveUsuario.Text == "") txtClaveUsuario.Text = "Contraseña Nueva";
        }

        private void txtConfirmacion_Enter(object sender, EventArgs e)
        {
            if (txtConfirmacion.Text == "Confirmar Clave") txtConfirmacion.Text = "";
        }

        private void txtConfirmacion_Leave(object sender, EventArgs e)
        {
            if (txtConfirmacion.Text == "") txtConfirmacion.Text = "Confirmar Clave";
        }
    }
}
