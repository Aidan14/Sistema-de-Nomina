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
    public partial class FormDetalles : Form
    {
        DetallesNegocios objNegocios = new DetallesNegocios();
        DetallesEntidades objEntidades = new DetallesEntidades();

        public struct Registro
        {
            public string nomina, empleado; public bool editarse;

            public Registro(string nomina, string empleado, bool editarse)
            {
                this.nomina = nomina;
                this.empleado = empleado;
                this.editarse = editarse;
            }

        }

        public FormDetalles()
        {
            InitializeComponent();
        }

        private void FormDetalles_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }

        public void mostrarBuscarTabla(string buscar)
        {
            tablaDetalles.DataSource = objNegocios.ListarDetalles(buscar);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscador.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro("", "", false);

            AbrirManejo(registro);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrarBuscarTabla("");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro(
                tablaDetalles.CurrentRow.Cells[0].Value.ToString(),
                tablaDetalles.CurrentRow.Cells[1].Value.ToString(),true);

            AbrirManejo(registro);
        }

        private void AbrirManejo(Registro registro)
        {
            Form formBG = new Form();
            using (ManejarDetalles frm = new ManejarDetalles(registro))
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