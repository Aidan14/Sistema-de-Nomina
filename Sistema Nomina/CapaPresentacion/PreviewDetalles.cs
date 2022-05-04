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
    public partial class PreviewDetalles : Form
    {
        string nomina;

        public PreviewDetalles(string _nomina)
        {
            nomina = _nomina;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PreviewDetalles_Load(object sender, EventArgs e)
        {
            ReporteDetalles reporte = new ReporteDetalles();
            reporte.SetParameterValue("@ID_Nomina", nomina);
            reportViewer.ReportSource = reporte;
        }
    }
}
