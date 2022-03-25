using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "Contraseña")
            {
                txtClave.Text = "";
                if (cbMostrarContraseña.IconChar == FontAwesome.Sharp.IconChar.Eye)
                {
                    txtClave.PasswordChar = '*';
                }
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                txtClave.Text = "Contraseña";
                txtClave.PasswordChar = '\0';
            }
        }

        private void cbMostrarContraseña_Click(object sender, EventArgs e)
        {
            if (cbMostrarContraseña.IconChar == FontAwesome.Sharp.IconChar.Eye)
            {
                cbMostrarContraseña.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                txtClave.PasswordChar = '\0';
            }
            else if (cbMostrarContraseña.IconChar == FontAwesome.Sharp.IconChar.EyeSlash)
            {
                cbMostrarContraseña.IconChar = FontAwesome.Sharp.IconChar.Eye;

                if (txtClave.Text != "Contraseña") txtClave.PasswordChar = '*';
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnLogin_Click(sender, e);
        }

        public struct Datos
        {
            public string nombre, clave;

            public Datos(string nombre, string clave)
            {
                this.nombre = nombre;
                this.clave = clave;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE Nombre = @Nombre AND Contraseña = @Contraseña", conexion);
            cmd.Parameters.AddWithValue("Nombre", txtUsuario.Text);
            cmd.Parameters.AddWithValue("Contraseña", txtClave.Text);

            conexion.Open();

            if (cmd.ExecuteReader().HasRows)
            {
                Datos datos1 = new Datos(txtUsuario.Text, txtClave.Text);
                new FormMenu(datos1).Show();
                this.Hide();
            }
            else MessageBox.Show("Las credenciales no coinciden");

            conexion.Close();
        }

        private void lbRecuperar_Click(object sender, EventArgs e)
        {
            new FormRecuperacion().Show();
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            switch (txt.Name)
            {
                case "txtUsuario": if (txt.Text == "Usuario") txt.Text = ""; break;
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            switch (txt.Name)
            {
                case "txtUsuario": if (txt.Text == "") txt.Text = "Usuario"; break;
            }
        }
    }
}