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
    public partial class FormJornadas : Form
    {
        JornadasNegocios objNegocios = new JornadasNegocios();
        JornadasEntidades objEntidades = new JornadasEntidades();

        public struct Registro
        {
            public string id, empleado, fecha, llegada, salida, observacion; public bool editarse;

            public Registro(string id, string empleado, string fecha, string llegada, string salida, string observacion, bool editarse)
            {
                this.id = id;
                this.empleado = empleado;
                this.fecha = fecha;
                this.llegada = llegada;
                this.salida = salida;
                this.observacion = observacion;
                this.editarse = editarse;
            }

        }

        public FormJornadas()
        {
            InitializeComponent();
        }

        private void FormJornadas_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }

        public void mostrarBuscarTabla(string buscar)
        {
            tablaJornadas.DataSource = objNegocios.ListarJornadas(buscar);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscador.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro("", "", "", "", "", "", false);

            AbrirManejo(registro);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrarBuscarTabla("");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(tablaJornadas.CurrentRow.Cells[2].Value.ToString());

            Registro registro = new Registro(
                tablaJornadas.CurrentRow.Cells[0].Value.ToString(),
                tablaJornadas.CurrentRow.Cells[1].Value.ToString(),
                fecha.ToString("dd/MM/yyyy"),
                tablaJornadas.CurrentRow.Cells[3].Value.ToString(),
                tablaJornadas.CurrentRow.Cells[4].Value.ToString(),
                tablaJornadas.CurrentRow.Cells[5].Value.ToString(), true);

            AbrirManejo(registro);
        }

        private void AbrirManejo(Registro registro)
        {
            Form formBG = new Form();
            using (ManejarJornadas frm = new ManejarJornadas(registro))
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
