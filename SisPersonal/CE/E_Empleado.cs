using System;

namespace CE
{
    public class E_Empleado:E_Marcaciones
    {
        public string ID_Empleado { get; set; }
        public string Ape_Paterno { get; set; }
        public string Ape_Materno { get; set; }
        public string Nombres { get; set; }
        public string DNI { get; set; }
        public string Direccion { get; set; }
        public byte[] Foto { get; set; }
        public Boolean Estado { get; set; }
        public decimal SBasicoHora { get; set; }
        public decimal SHorasExtraHora { get; set; }
    }
}