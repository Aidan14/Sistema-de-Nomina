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
    public partial class ManejarCargos : Form
    {
        bool editarse = false;
        CargosNegocios objNegocios = new CargosNegocios();
        CargosEntidades objEntidades = new CargosEntidades();

        FormCargos.Registro registro;

        public ManejarCargos(FormCargos.Registro _registro)
        {
            InitializeComponent();
            registro = _registro;
        }
        private void ManejarCargos_Load(object sender, EventArgs e)
        {
            LlenarComboBoxes();

            if (registro.editarse == false)
            {
                cbID.Visible = false;
                lbFuncion.Text = "Agregar Cargo";
            }
            else
            {
                cbID.Text = registro.id;
                txtNombre.Text = registro.nombre;
                editarse = true;
                lbFuncion.Text = "Editar Cargo";
            }
        }

        private void LlenarComboBoxes()
        {
            cbID.DataSource = objNegocios.ListarCargos("");
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

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre") txtNombre.Text = "";
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "") txtNombre.Text = "Nombre";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!editarse)
            {
                try
                {
                    objEntidades.Nombre = txtNombre.Text;

                    objNegocios.InsertarCargo(objEntidades);

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

                    objNegocios.EditarCargo(objEntidades);

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
