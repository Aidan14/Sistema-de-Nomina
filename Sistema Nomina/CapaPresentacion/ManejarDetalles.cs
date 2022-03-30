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
    public partial class ManejarDetalles : Form
    {
        bool editarse = false;
        DetallesNegocios objNegocios = new DetallesNegocios();
        DetallesEntidades objEntidades = new DetallesEntidades();

        FormDetalles.Registro registro;

        public ManejarDetalles(FormDetalles.Registro _registro)
        {
            InitializeComponent();
            registro = _registro;
        }

        private void ManejarDetalles_Load(object sender, EventArgs e)
        {
            LlenarComboBoxes();

            if (registro.editarse == false)
            {
                lbFuncion.Text = "Agregar Detalle";
            }
            else
            {
                cbNomina.Text = registro.nomina;
                cbEmpleado.Text = registro.empleado;
                editarse = true;
                lbFuncion.Text = "Editar Detalle";
            }

            tablaJornadas.Columns[5].Visible = false;
        }

        private void LlenarComboBoxes()
        {
            NominasNegocios nomina = new NominasNegocios();
            cbNomina.DataSource = nomina.ListarNominas("");
            cbNomina.DisplayMember = "ID";
            cbNomina.ValueMember = "ID";

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
                    objEntidades.Nomina = Convert.ToInt32(cbNomina.Text);
                    objEntidades.Empleado = Convert.ToInt32(cbEmpleado.Text);
                    objEntidades.Bruto = Convert.ToDouble(lbBruto.Text);
                    objEntidades.Horas_Trabajadas = Convert.ToInt32(lbHT.Text);
                    objEntidades.AFP = Convert.ToDouble(lbAFP.Text);
                    objEntidades.ARS = Convert.ToDouble(lbARS.Text);
                    objEntidades.ISR = Convert.ToDouble(lbISR.Text);
                    objEntidades.Neto = Convert.ToDouble(lbNeto.Text);

                    objNegocios.InsertarDetalle(objEntidades);

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
                    objEntidades.Nomina = Convert.ToInt32(cbNomina.Text);
                    objEntidades.Empleado = Convert.ToInt32(cbEmpleado.Text);
                    objEntidades.Bruto = Convert.ToDouble(lbBruto.Text);
                    objEntidades.Horas_Trabajadas = Convert.ToInt32(lbHT.Text);
                    objEntidades.AFP = Convert.ToDouble(lbAFP.Text);
                    objEntidades.ARS = Convert.ToDouble(lbARS.Text);
                    objEntidades.ISR = Convert.ToDouble(lbISR.Text);
                    objEntidades.Neto = Convert.ToDouble(lbNeto.Text);

                    objNegocios.EditarDetalle(objEntidades);

                    MessageBox.Show("Se edito el registro");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
        }

        private void cb_TextChanged(object sender, EventArgs e)
        {
            JornadasNegocios negocios = new JornadasNegocios();
            if ("1234567890".Contains(cbNomina.Text) && "1234567890".Contains(cbEmpleado.Text) && cbNomina.Text != "" && cbEmpleado.Text != "")
            {
                int nomina = Convert.ToInt32(cbNomina.Text);
                int empleado = Convert.ToInt32(cbEmpleado.Text);
                tablaJornadas.DataSource = negocios.ListarEspecifica(nomina, empleado);

                try
                {
                    Calcular();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
            }
        }

        private void Calcular()
        {
            EmpleadosNegocios empleados = new EmpleadosNegocios();

            double pagoHN = empleados.SueldoEmpleado(Convert.ToInt32(cbEmpleado.Text));
            double pagoHE = pagoHN * 1.25;

            int HT = 0;

            for (int i = 0; i<tablaJornadas.RowCount; i++)
            {
                TimeSpan horaEntrada = TimeSpan.Parse(tablaJornadas.Rows[i].Cells["Llegada"].Value.ToString());
                TimeSpan horaSalida = TimeSpan.Parse(tablaJornadas.Rows[i].Cells["Salida"].Value.ToString());

                HT += horaSalida.Subtract(horaEntrada).Hours;
            }

            int HN = 0;
            int HE = 0;

            if (HT <= 88) HN = HT;
            else
            {
                HN = 88;
                HE = HT - 88;
            }

            double bruto = (HN * pagoHN) + (HE * pagoHE);

            double AFP = (bruto * (3.92 / 100));
            double ARS = (bruto * (2.58 / 100));

            double AntesISR = bruto - (AFP + ARS);
            double ISR = 0;

            if (AntesISR > 34685 && AntesISR <= 52027) ISR = AntesISR * 0.15;
            else if (AntesISR > 52027 && AntesISR <= 72260) ISR = AntesISR * 0.2;
            else if (AntesISR > 72260) ISR = AntesISR * 0.25;

            double neto = AntesISR - ISR;

            lbHT.Text = Convert.ToString(HT);
            lbHE.Text = Convert.ToString(HE);
            lbPagoHN.Text = Convert.ToString(pagoHN);
            lbPagoHE.Text = Convert.ToString(pagoHE);
            lbARS.Text = Convert.ToString(ARS);
            lbAFP.Text = Convert.ToString(AFP);
            lbAntesISR.Text = Convert.ToString(AntesISR);
            lbISR.Text = Convert.ToString(ISR);
            lbBruto.Text = Convert.ToString(bruto);
            lbNeto.Text = Convert.ToString(neto);

        }
    }
}
