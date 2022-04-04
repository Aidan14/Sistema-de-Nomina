using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EmpleadosEntidades
    {
        private int _ID;
        private string _Cedula;
        private string _Nombre;
        private DateTime _Fecha_Nacimiento;
        private int _Departamento;
        private int _Cargo;
        private int _Horario;
        private char _Sexo;
        private string _Telefono;
        private string _Direccion;
        private string _Estado;
        private double _Pago_Hora;

        public int ID { get => _ID; set => _ID = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public DateTime Fecha_Nacimiento { get => _Fecha_Nacimiento; set => _Fecha_Nacimiento = value; }
        public int Departamento { get => _Departamento; set => _Departamento = value; }
        public int Cargo { get => _Cargo; set => _Cargo = value; }
        public int Horario { get => _Horario; set => _Horario = value; }
        public char Sexo { get => _Sexo; set => _Sexo = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public double Pago_Hora { get => _Pago_Hora; set => _Pago_Hora = value; }
    }
}
