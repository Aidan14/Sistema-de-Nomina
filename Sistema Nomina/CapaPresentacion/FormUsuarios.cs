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
    public partial class FormUsuarios : Form
    {
        UsuariosNegocios objNegocios = new UsuariosNegocios();
        UsuariosEntidades objEntidades = new UsuariosEntidades();

        public struct Registro
        {
            public string id, nombre, contraseña, rol; public bool editarse;

            public Registro(string id, string nombre, string contraseña, string rol, bool editarse)
            {
                this.id = id;
                this.nombre = nombre;
                this.contraseña = contraseña;
                this.rol = rol;
                this.editarse = editarse;
            }

        }

        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }

        public void mostrarBuscarTabla(string buscar)
        {
            tablaUsuarios.DataSource = objNegocios.ListarUsuarios(buscar);
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
                tablaUsuarios.CurrentRow.Cells[0].Value.ToString(),
                tablaUsuarios.CurrentRow.Cells[1].Value.ToString(),
                tablaUsuarios.CurrentRow.Cells[2].Value.ToString(),
                tablaUsuarios.CurrentRow.Cells[3].Value.ToString(), true);

            AbrirManejo(registro);
        }

        private void AbrirManejo(Registro registro)
        {
            Form formBG = new Form();
            using (ManejarUsuarios frm = new ManejarUsuarios(registro))
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
