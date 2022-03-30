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
    public partial class FormEmpleados : Form
    {
        EmpleadosNegocios objNegocios = new EmpleadosNegocios();
        EmpleadosEntidades objEntidades = new EmpleadosEntidades();

        public struct Registro
        {
            public string id, cedula, nombre, nacimiento, departamento, cargo, sexo, telefono, direccion, estado, pago; public bool editarse;

            public Registro(string id, string cedula, string nombre, string nacimiento, string departamento, string cargo, string sexo, string telefono, string direccion, string estado, string pago, bool editarse)
            {
                this.id = id;
                this.cedula = cedula;
                this.nombre = nombre;
                this.nacimiento = nacimiento;
                this.departamento = departamento;
                this.cargo = cargo;
                this.sexo = sexo;
                this.telefono = telefono;
                this.direccion = direccion;
                this.estado = estado;
                this.pago = pago;
                this.editarse = editarse;
            }

        }

        public FormEmpleados()
        {
            InitializeComponent();
        }

        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }

        public void mostrarBuscarTabla(string buscar)
        {
            tablaEmpleados.DataSource = objNegocios.ListarEmpleados(buscar);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscador.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro("", "", "", "", "", "", "", "", "", "", "", false);

            AbrirManejo(registro);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrarBuscarTabla("");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DateTime nac = Convert.ToDateTime(tablaEmpleados.CurrentRow.Cells[3].Value.ToString());

            Registro registro = new Registro(
                tablaEmpleados.CurrentRow.Cells[0].Value.ToString(),
                tablaEmpleados.CurrentRow.Cells[1].Value.ToString(),
                tablaEmpleados.CurrentRow.Cells[2].Value.ToString(),
                nac.ToString("dd/MM/yyyy"),
                tablaEmpleados.CurrentRow.Cells[4].Value.ToString(),
                tablaEmpleados.CurrentRow.Cells[5].Value.ToString(),
                tablaEmpleados.CurrentRow.Cells[6].Value.ToString(),
                tablaEmpleados.CurrentRow.Cells[7].Value.ToString(),
                tablaEmpleados.CurrentRow.Cells[8].Value.ToString(),
                tablaEmpleados.CurrentRow.Cells[9].Value.ToString(),
                tablaEmpleados.CurrentRow.Cells[10].Value.ToString(), true);

            AbrirManejo(registro);
        }

        private void AbrirManejo(Registro registro)
        {
            Form formBG = new Form();
            using (ManejarEmpleados frm = new ManejarEmpleados(registro))
            {
                formBG.StartPosition = FormStartPosition.Manual;
                formBG.FormBorderStyle = FormBorderStyle.None;
                formBG.Opacity = .60d;
                formBG.BackColor = Color.Black;
                formBG.WindowState = FormWindowState.Maximized;
                formBG.TopMost = true;
                formBG.Location = this.Location;
                formBG.ShowInTaskbar = false;
                formBG.Show();

                frm.Owner = formBG;
                frm.TopMost = true;
                frm.FormClosing += new FormClosingEventHandler(this.Form2_FormClosing);
                frm.ShowDialog();

                formBG.Dispose();
            }
        }
    }
}
