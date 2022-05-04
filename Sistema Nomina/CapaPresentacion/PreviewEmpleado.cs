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
    public partial class PreviewEmpleado : Form
    {
        FormDetalles.Datos datos;

        public PreviewEmpleado(FormDetalles.Datos _datos)
        {
            datos = _datos;
            InitializeComponent();
        }

        private void PreviewEmpleado_Load(object sender, EventArgs e)
        {
            ReporteEmpleado reporte = new ReporteEmpleado();
            reporte.SetParameterValue("@ID_Nomina", datos.nomina);
            reporte.SetParameterValue("@ID_Empleado", datos.empleado);
            reportViewer.ReportSource = reporte;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
