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
    public partial class ManejarEmpleados : Form
    {
        bool editarse = false, inactivo = false;
        EmpleadosNegocios objNegocios = new EmpleadosNegocios();
        EmpleadosEntidades objEntidades = new EmpleadosEntidades();

        FormEmpleados.Registro registro;

        public ManejarEmpleados(FormEmpleados.Registro _registro)
        {
            InitializeComponent();
            registro = _registro;
        }

        private void ManejarEmpleados_Load(object sender, EventArgs e)
        {
            LlenarComboBoxes();

            if (registro.editarse == false)
            {
                cbID.Visible = false;
                lbFuncion.Text = "Agregar Empleado";
            }
            else
            {
                cbID.Text = registro.id;
                txtCedula.Text = registro.cedula;
                txtNombre.Text = registro.nombre;
                mtxtNacimiento.Text = registro.nacimiento;
                cbDepartamento.Text = registro.departamento;
                cbCargo.Text = registro.cargo;

                if (registro.sexo == "M") rbM.Checked = true;
                else if (registro.sexo == "F") rbF.Checked = true;

                mtxtTelefono.Text = registro.telefono;
                txtDireccion.Text = registro.direccion;

                if (registro.estado != btnEstado.Text) inactivo = true;

                txtPago.Text = registro.pago;

                editarse = true;
                lbFuncion.Text = "Editar Empleado";
            }
            if (inactivo) btnEstado.PerformClick();
        }

        private void LlenarComboBoxes()
        {
            cbID.DataSource = objNegocios.ListarEmpleados("");
            cbID.DisplayMember = "ID";
            cbID.ValueMember = "ID";

            DepartamentosNegocios departamentos = new DepartamentosNegocios();
            cbDepartamento.DataSource = departamentos.ListarDepartamentos("");
            cbDepartamento.DisplayMember = "ID";
            cbDepartamento.ValueMember = "ID";

            CargosNegocios cargos = new CargosNegocios();
            cbCargo.DataSource = cargos.ListarCargos("");
            cbCargo.DisplayMember = "ID";
            cbCargo.ValueMember = "ID";
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
                    objEntidades.Cedula = txtCedula.Text;
                    objEntidades.Nombre = txtNombre.Text;
                    objEntidades.Fecha_Nacimiento = Convert.ToDateTime(mtxtNacimiento.Text);
                    objEntidades.Departamento = Convert.ToInt32(cbDepartamento.Text);
                    objEntidades.Cargo = Convert.ToInt32(cbCargo.Text);

                    if (rbM.Checked) objEntidades.Sexo = 'M';
                    else objEntidades.Sexo = 'F';

                    objEntidades.Telefono = mtxtTelefono.Text;
                    objEntidades.Direccion = txtDireccion.Text;

                    if (btnEstado.Text == "Activo") objEntidades.Estado = "Activo";
                    else objEntidades.Estado = "Inactivo";

                    objEntidades.Pago_Hora = Convert.ToDouble(txtPago.Text);

                    objNegocios.InsertarEmpleado(objEntidades);

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
                    objEntidades.Cedula = txtCedula.Text;
                    objEntidades.Nombre = txtNombre.Text;
                    objEntidades.Fecha_Nacimiento = Convert.ToDateTime(mtxtNacimiento.Text);
                    objEntidades.Departamento = Convert.ToInt32(cbDepartamento.Text);
                    objEntidades.Cargo = Convert.ToInt32(cbCargo.Text);

                    if (rbM.Checked) objEntidades.Sexo = 'M';
                    else objEntidades.Sexo = 'F';

                    objEntidades.Telefono = mtxtTelefono.Text;
                    objEntidades.Direccion = txtDireccion.Text;

                    if (btnEstado.Text == "Activo") objEntidades.Estado = "Activo";
                    else objEntidades.Estado = "Inactivo";

                    objEntidades.Pago_Hora = Convert.ToDouble(txtPago.Text);

                    objNegocios.EditarEmpleado(objEntidades);

                    MessageBox.Show("Se edito el registro");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            if (btnEstado.Text == "Activo")
            {
                btnEstado.Text = "Inactivo";
                btnEstado.BackColor = Color.FromArgb(221, 75, 57);
                btnEstado.IconChar = FontAwesome.Sharp.IconChar.Times;
            }
            else
            {
                btnEstado.Text = "Activo";
                btnEstado.BackColor = Color.FromArgb(0, 166, 90);
                btnEstado.IconChar = FontAwesome.Sharp.IconChar.Check;
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            switch (txt.Name)
            {
                case "txtCedula": if (txt.Text == "Cedula") txt.Text = ""; break;
                case "txtNombre": if (txt.Text == "Nombre") txt.Text = ""; break;
                case "txtDireccion": if (txt.Text == "Direccion") txt.Text = ""; break;
                case "txtPago": if (txt.Text == "Pago") txt.Text = ""; break;
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            switch (txt.Name)
            {
                case "txtCedula": if (txt.Text == "") txt.Text = "Cedula"; break;
                case "txtNombre": if (txt.Text == "") txt.Text = "Nombre"; break;
                case "txtDireccion": if (txt.Text == "") txt.Text = "Direccion"; break;
                case "txtPago": if (txt.Text == "") txt.Text = "Pago"; break;
            }
        }
    }
}
