using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormConfiguracion : Form
    {
        public FormConfiguracion()
        {
            InitializeComponent();
        }

        private void FormConfiguracion_Load(object sender, EventArgs e)
        {
            txtAFP.Text = Properties.Settings.Default.afpPorcentaje.ToString();
            txtARS.Text = Properties.Settings.Default.arsPorcentaje.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.afpPorcentaje = Convert.ToDouble(txtAFP.Text);
            Properties.Settings.Default.arsPorcentaje = Convert.ToDouble(txtARS.Text);
            Properties.Settings.Default.Save();

            MessageBox.Show("Se han aplicado los cambios");

        }

        private void numTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!"1234567890.".Contains(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }
    }
}
