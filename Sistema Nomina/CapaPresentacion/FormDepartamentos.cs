﻿using System;
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
    public partial class FormDepartamentos : Form
    {
        DepartamentosNegocios objNegocios = new DepartamentosNegocios();
        DepartamentosEntidades objEntidades = new DepartamentosEntidades();

        public struct Registro
        {
            public string id, nombre; public bool editarse;

            public Registro(string id, string nombre, bool editarse)
            {
                this.id = id;
                this.nombre = nombre;
                this.editarse = editarse;
            }

        }

        public FormDepartamentos()
        {
            InitializeComponent();
        }

        private void FormDepartamentos_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }

        public void mostrarBuscarTabla(string buscar)
        {
            tablaDepartamentos.DataSource = objNegocios.ListarDepartamentos(buscar);
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
            if (tablaDepartamentos.RowCount <= 0) return;
            Registro registro = new Registro(
                tablaDepartamentos.CurrentRow.Cells[0].Value.ToString(),
                tablaDepartamentos.CurrentRow.Cells[1].Value.ToString(), true);

            AbrirManejo(registro);
        }

        private void AbrirManejo(Registro registro)
        {
            Form formBG = new Form();
            using (ManejarDepartamentos frm = new ManejarDepartamentos(registro))
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
