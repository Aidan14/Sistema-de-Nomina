using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class DetallesEntidades
    {
        private int _Nomina;
        private int _Empleado;
        private double _Bruto;
        private int _Horas_Trabajadas;
        private double _AFP;
        private double _ARS;
        private double _ISR;
        private double _Neto;

        public int Nomina { get => _Nomina; set => _Nomina = value; }
        public int Empleado { get => _Empleado; set => _Empleado = value; }
        public double Bruto { get => _Bruto; set => _Bruto = value; }
        public int Horas_Trabajadas { get => _Horas_Trabajadas; set => _Horas_Trabajadas = value; }
        public double AFP { get => _AFP; set => _AFP = value; }
        public double ARS { get => _ARS; set => _ARS = value; }
        public double ISR { get => _ISR; set => _ISR = value; }
        public double Neto { get => _Neto; set => _Neto = value; }
    }
}
