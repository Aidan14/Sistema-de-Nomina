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
    public partial class FormNominas : Form
    {
        NominasNegocios objNegocios = new NominasNegocios();
        NominasEntidades objEntidades = new NominasEntidades();

        public struct Registro
        {
            public string id, usuario, fecha, desde, hasta; public bool editarse;

            public Registro(string id, string usuario, string fecha, string desde, string hasta, bool editarse)
            {
                this.id = id;
                this.usuario = usuario;
                this.fecha = fecha;
                this.desde = desde;
                this.hasta = hasta;
                this.editarse = editarse;
            }

        }

        public FormNominas()
        {
            InitializeComponent();
        }

        private void FormNominas_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }

        public void mostrarBuscarTabla(string buscar)
        {
            tablaNominas.DataSource = objNegocios.ListarNominas(buscar);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscador.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            Registro registro = new Registro();
            
            if (tablaNominas.RowCount > 0) registro = new Registro(Convert.ToString(Convert.ToInt32(tablaNominas.Rows[tablaNominas.Rows.Count - 1].Cells["ID"].Value.ToString()) + 1), "", "", "", "", false);

            AbrirManejo(registro);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrarBuscarTabla("");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaNominas.RowCount <= 0) return;
            DateTime fecha = Convert.ToDateTime(tablaNominas.CurrentRow.Cells[2].Value.ToString());
            DateTime desde = Convert.ToDateTime(tablaNominas.CurrentRow.Cells[3].Value.ToString());
            DateTime hasta = Convert.ToDateTime(tablaNominas.CurrentRow.Cells[4].Value.ToString());

            Registro registro = new Registro(
                tablaNominas.CurrentRow.Cells[0].Value.ToString(),
                tablaNominas.CurrentRow.Cells[1].Value.ToString(),
                fecha.ToString("dd/MM/yyyy"),
                desde.ToString("dd/MM/yyyy"),
                hasta.ToString("dd/MM/yyyy"), true);

            AbrirManejo(registro);
        }

        private void AbrirManejo(Registro registro)
        {
            Form formBG = new Form();
            using (ManejarNominas frm = new ManejarNominas(registro))
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (tablaNominas.RowCount <= 0) return;
            string datos = tablaNominas.CurrentRow.Cells[0].Value.ToString();

            Form formBG = new Form();
            using (PreviewDetalles frm = new PreviewDetalles(datos))
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