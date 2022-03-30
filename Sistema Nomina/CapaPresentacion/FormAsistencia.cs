using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using System.Configuration;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class FormAsistencia : Form
    {
        JornadasNegocios objNegocios = new JornadasNegocios();
        JornadasEntidades objEntidades = new JornadasEntidades();

        public FormAsistencia()
        {
            InitializeComponent();
            lbHora.Text = DateTime.Now.ToString("hh:mm:ss tt").ToUpper();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString("hh:mm:ss tt").ToUpper();
        }

        private void FormAsistencia_Load(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToString("ddd dd De MMMM yyyy");
            timer1.Start();

            EmpleadosNegocios empleados = new EmpleadosNegocios();
            cbID.DataSource = empleados.ListarEmpleados("");
            cbID.DisplayMember = "ID";
            cbID.ValueMember = "ID";
        }

        private void cbID_TextChanged(object sender, EventArgs e)
        {
            if ("1234567890".Contains(cbID.Text))
            {
                objEntidades.Empleado = Convert.ToInt32(cbID.Text);
                objEntidades.Fecha = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                if (objNegocios.RevisarLlegada(objEntidades) == "llego") btnPonche.Text = "Salir";
                else if (objNegocios.RevisarLlegada(objEntidades) == "no llego") btnPonche.Text = "Ingresar";
                else btnPonche.Text = "Jornada Completada";
            }
        }

        private void btnPonche_Click(object sender, EventArgs e)
        {
            objEntidades.Empleado = Convert.ToInt32(cbID.Text);
            objEntidades.Fecha = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

            if (objNegocios.RevisarLlegada(objEntidades) == "no llego")
            {
                objEntidades.Llegada = TimeSpan.Parse(DateTime.Now.ToString("hh:mm:ss"));
                objEntidades.Observacion = "";

                objNegocios.InsertarJornada(objEntidades);

                MessageBox.Show("Llegada registrada");
                btnPonche.Text = "Salir";
            }
            else if (objNegocios.RevisarLlegada(objEntidades) == "llego")
            {
                objEntidades.Salida = TimeSpan.Parse(DateTime.Now.ToString("hh:mm:ss"));

                objNegocios.InsertarSalida(objEntidades);

                MessageBox.Show("Salida registrada");
                btnPonche.Text = "Jornada Completada";
            }
        }
    }
}
