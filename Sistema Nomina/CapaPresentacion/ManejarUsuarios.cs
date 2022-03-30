using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class ManejarUsuarios : Form
    {
        bool editarse = false;
        UsuariosNegocios objNegocios = new UsuariosNegocios();
        UsuariosEntidades objEntidades = new UsuariosEntidades();

        FormUsuarios.Registro registro;

        public ManejarUsuarios(FormUsuarios.Registro _registro)
        {
            InitializeComponent();
            registro = _registro;
        }
        private void ManejarUsuarios_Load(object sender, EventArgs e)
        {
            LlenarComboBoxes();

            if (registro.editarse == false)
            {
                cbID.Visible = false;
                lbFuncion.Text = "Agregar Usuario";
            }
            else
            {
                cbID.Text = registro.id;
                txtNombre.Text = registro.nombre;
                txtContraseña.Text = registro.contraseña;
                txtRol.Text = registro.rol;
                editarse = true;
                lbFuncion.Text = "Editar Usuario";
            }
        }

        private void LlenarComboBoxes()
        {
            cbID.DataSource = objNegocios.ListarUsuarios("");
            cbID.DisplayMember = "ID";
            cbID.ValueMember = "ID";
        }

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!editarse)
            {
                try
                {
                    objEntidades.Nombre = txtNombre.Text;
                    objEntidades.Nombre = txtNombre.Text;
                    objEntidades.Contraseña = txtContraseña.Text;
                    objEntidades.Rol = txtRol.Text;

                    objNegocios.InsertarUsuario(objEntidades);

                    MessageBox.Show("Se guardo el registro");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
            else
            {
                try
                {
                    objEntidades.ID = Convert.ToInt32(cbID.Text);
                    objEntidades.Nombre = txtNombre.Text;
                    objEntidades.Contraseña = txtContraseña.Text;
                    objEntidades.Rol = txtRol.Text;

                    objNegocios.EditarUsuario(objEntidades);

                    MessageBox.Show("Se edito el registro");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
        }
    }
}
