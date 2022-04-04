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
    public partial class ManejarNominas : Form
    {
        bool editarse = false; int idNomina;
        NominasNegocios objNegocios = new NominasNegocios();
        NominasEntidades objEntidades = new NominasEntidades();

        FormNominas.Registro registro;

        public ManejarNominas(FormNominas.Registro _registro)
        {
            InitializeComponent();
            registro = _registro;
        }
        private void ManejarNominas_Load(object sender, EventArgs e)
        {
            LlenarComboBoxes();

            if (registro.editarse == false)
            {
                cbID.Text = registro.id;
                cbID.KeyPress += new KeyPressEventHandler(this.cbID_KeyPress);
                mtxtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lbFuncion.Text = "Agregar Nomina";
            }
            else
            {
                cbID.Text = registro.id;
                cbUsuario.Text = registro.usuario;
                mtxtFecha.Text = registro.fecha;
                mtxtDesde.Text = registro.desde;
                mtxtHasta.Text = registro.hasta;
                editarse = true;
                lbFuncion.Text = "Editar Nomina";
            }
        }

        private void LlenarComboBoxes()
        {
            UsuariosNegocios empleados = new UsuariosNegocios();
            cbUsuario.DataSource = empleados.ListarUsuarios("");
            cbUsuario.DisplayMember = "ID";
            cbUsuario.ValueMember = "ID";
            
            if (!registro.editarse) return;
            cbID.DataSource = objNegocios.ListarNominas("");
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

        private void cbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
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
                    objEntidades.Usuario = Convert.ToInt32(cbUsuario.Text);
                    objEntidades.Fecha = Convert.ToDateTime(mtxtFecha.Text);
                    objEntidades.Desde = Convert.ToDateTime(mtxtDesde.Text);
                    objEntidades.Hasta = Convert.ToDateTime(mtxtHasta.Text);

                    objNegocios.InsertarNomina(objEntidades);

                    if (cBAuto.Checked) GenerarDetalles();

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
                    objEntidades.Usuario = Convert.ToInt32(cbUsuario.Text);
                    objEntidades.Fecha = Convert.ToDateTime(mtxtFecha.Text);
                    objEntidades.Desde = Convert.ToDateTime(mtxtDesde.Text);
                    objEntidades.Hasta = Convert.ToDateTime(mtxtHasta.Text);

                    objNegocios.EditarNomina(objEntidades);

                    MessageBox.Show("Se edito el registro");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
        }

        private void rb15_CheckedChanged(object sender, EventArgs e)
        {
            mtxtDesde_TextChanged(sender, e);
        }

        private void mtxtDesde_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rb15.Checked == true) mtxtHasta.Text = Convert.ToDateTime(mtxtDesde.Text).AddDays(14).ToString("dd/MM/yyyy");
                else mtxtHasta.Text = Convert.ToDateTime(mtxtDesde.Text).AddDays(29).ToString("dd/MM/yyyy");
            }
            catch(System.FormatException){}
        }

        private void GenerarDetalles()
        {
            EmpleadosNegocios empleados = new EmpleadosNegocios();
            JornadasNegocios jornadas = new JornadasNegocios();
            DetallesNegocios detalles = new DetallesNegocios();
            HorariosNegocios horarios = new HorariosNegocios();

            idNomina = Convert.ToInt32(cbID.Text);

            DataTable dtEmpleados = empleados.ListarActivos();
            for (int i = 0; i < dtEmpleados.Rows.Count; i++)
            {
                int idEmpleado = Convert.ToInt32(dtEmpleados.Rows[i]["ID_Empleado"].ToString());
                int pagoHN = Convert.ToInt32(dtEmpleados.Rows[i]["Pago_Hora"].ToString());
                double pagoHE = pagoHN * 1.25;

                DataTable dtJornadas = jornadas.ListarEspecifica(idNomina, idEmpleado.ToString());

                double HT = 0;
                double HN = 0;
                double HE = 0;

                double HorasHorario = horarios.Horas(Convert.ToInt32(empleados.HorarioEmpleado(idEmpleado)));

                for (int j = 0; j < dtJornadas.Rows.Count; j++)
                {
                    TimeSpan horaEntrada = TimeSpan.Parse(dtJornadas.Rows[i]["Hora_Entrada"].ToString());
                    TimeSpan horaSalida = TimeSpan.Parse(dtJornadas.Rows[i]["Hora_Salida"].ToString());

                    HT += horaSalida.Subtract(horaEntrada).Hours;

                    if (horaSalida.Subtract(horaEntrada).Hours > HorasHorario)
                    {
                        HN += horaSalida.Subtract(horaEntrada).Hours;
                        HE += horaSalida.Subtract(horaEntrada).Hours - HorasHorario;
                    }
                    else HN += horaSalida.Subtract(horaEntrada).Hours;
                }

                if (HT == 0) continue;

                double bruto = Math.Round((HN * pagoHN) + (HE * pagoHE));

                double AFP = Math.Round((bruto * (3.92 / 100)), 2);
                double ARS = Math.Round((bruto * (2.58 / 100)), 2);

                double AntesISR = Math.Round(bruto - (AFP + ARS), 2);
                double ISR = 0;

                if (AntesISR > 34685 && AntesISR <= 52027) ISR = Math.Round(AntesISR * 0.15);
                else if (AntesISR > 52027 && AntesISR <= 72260) ISR = Math.Round(AntesISR * 0.2, 2);
                else if (AntesISR > 72260) Math.Round(ISR = AntesISR * 0.25, 2);

                double neto = Math.Round(AntesISR - ISR, 2);

                detalles.InsertarDetalle(new DetallesEntidades
                {
                    Nomina = idNomina,
                    Empleado = idEmpleado,
                    Bruto = bruto,
                    Horas_Trabajadas = (int)HT,
                    AFP = AFP,
                    ARS = ARS,
                    ISR = ISR,
                    Neto = neto
                });
            }
        }
    }
}
