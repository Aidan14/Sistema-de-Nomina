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
    public partial class ManejarJornadas : Form
    {
        bool editarse = false;
        JornadasNegocios objNegocios = new JornadasNegocios();
        JornadasEntidades objEntidades = new JornadasEntidades();

        FormJornadas.Registro registro;

        public ManejarJornadas(FormJornadas.Registro _registro)
        {
            InitializeComponent();
            registro = _registro;
        }
        private void ManejarJornadas_Load(object sender, EventArgs e)
        {
            LlenarComboBoxes();

            if (registro.editarse == false)
            {
                cbID.Visible = false;
                lbFuncion.Text = "Agregar Jornada";
            }
            else
            {
                cbID.Text = registro.id;
                cbEmpleado.Text = registro.empleado;
                mtxtFecha.Text = registro.fecha;
                mtxtLlegada.Text = registro.llegada;
                mtxtSalida.Text = registro.salida;
                txtObservacion.Text = registro.observacion;
                editarse = true;
                lbFuncion.Text = "Editar Jornada";
            }
        }

        private void LlenarComboBoxes()
        {
            cbID.DataSource = objNegocios.ListarJornadas("");
            cbID.DisplayMember = "ID";
            cbID.ValueMember = "ID";

            EmpleadosNegocios empleados = new EmpleadosNegocios();
            cbEmpleado.DataSource = empleados.ListarEmpleados("");
            cbEmpleado.DisplayMember = "ID";
            cbEmpleado.ValueMember = "ID";
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
                    objEntidades.Empleado = Convert.ToInt32(cbEmpleado.Text);
                    objEntidades.Fecha = Convert.ToDateTime(mtxtFecha.Text);
                    objEntidades.Llegada = TimeSpan.Parse(mtxtLlegada.Text);
                    objEntidades.Salida = TimeSpan.Parse(mtxtSalida.Text);
                    objEntidades.Observacion = txtObservacion.Text;

                    objNegocios.InsertarJornada(objEntidades);

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
                    objEntidades.Empleado = Convert.ToInt32(cbEmpleado.Text);
                    objEntidades.Fecha = Convert.ToDateTime(mtxtFecha.Text);
                    objEntidades.Llegada = TimeSpan.Parse(mtxtLlegada.Text);
                    objEntidades.Salida = TimeSpan.Parse(mtxtSalida.Text);
                    objEntidades.Observacion = txtObservacion.Text;

                    objNegocios.EditarJornada(objEntidades);

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
