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
    public partial class FormHorarios : Form
    {
        HorariosNegocios objNegocios = new HorariosNegocios();
        HorariosEntidades objEntidades = new HorariosEntidades();

        public struct Registro
        {
            public string id, tipo, desde, hasta; public bool editarse;

            public Registro(string id, string tipo, string desde, string hasta, bool editarse)
            {
                this.id = id;
                this.tipo = tipo;
                this.desde = desde;
                this.hasta = hasta;
                this.editarse = editarse;
            }

        }

        public FormHorarios()
        {
            InitializeComponent();
        }

        private void FormHorarios_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }

        public void mostrarBuscarTabla(string buscar)
        {
            tablaHorarios.DataSource = objNegocios.ListarHorarios(buscar);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscador.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro("", "", "", "", false);

            AbrirManejo(registro);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrarBuscarTabla("");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro(
                tablaHorarios.CurrentRow.Cells[0].Value.ToString(),
                tablaHorarios.CurrentRow.Cells[1].Value.ToString(),
                tablaHorarios.CurrentRow.Cells[2].Value.ToString(),
                tablaHorarios.CurrentRow.Cells[3].Value.ToString(), true);

            AbrirManejo(registro);
        }

        private void AbrirManejo(Registro registro)
        {
            Form formBG = new Form();
            using (ManejarHorarios frm = new ManejarHorarios(registro))
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