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
    public partial class ManejarHorarios : Form
    {
        bool editarse = false;
        HorariosNegocios objNegocios = new HorariosNegocios();
        HorariosEntidades objEntidades = new HorariosEntidades();

        FormHorarios.Registro registro;

        public ManejarHorarios(FormHorarios.Registro _registro)
        {
            InitializeComponent();
            registro = _registro;
        }

        private void ManejarHorarios_Load(object sender, EventArgs e)
        {
            LlenarComboBoxes();

            if (registro.editarse == false)
            {
                cbID.Visible = false;
                lbFuncion.Text = "Agregar Horario";
            }
            else
            {
                cbID.Text = registro.id;
                txtTipo.Text = registro.tipo;
                mtxtDesde.Text = registro.desde;
                mtxtHasta.Text = registro.hasta;
                editarse = true;
                lbFuncion.Text = "Editar Horario";
            }
        }

        private void LlenarComboBoxes()
        {
            cbID.DataSource = objNegocios.ListarHorarios("");
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
                    objEntidades.Tipo = txtTipo.Text;
                    objEntidades.Desde = TimeSpan.Parse(mtxtDesde.Text);
                    objEntidades.Hasta = TimeSpan.Parse(mtxtHasta.Text);

                    objNegocios.InsertarHorario(objEntidades);

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
                    objEntidades.Tipo = txtTipo.Text;
                    objEntidades.Desde = TimeSpan.Parse(mtxtDesde.Text);
                    objEntidades.Hasta = TimeSpan.Parse(mtxtHasta.Text);

                    objNegocios.EditarHorario(objEntidades);

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
