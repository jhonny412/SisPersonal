using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE
{
    public class E_Marcaciones
    {
        public int Id_Marcacion { get; set; }
        public String Id_Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime H_Ingreso { get; set; }
        public DateTime HS_Refrigerio { get; set; }
        public DateTime HI_Refrigerio { get; set; }
        public DateTime H_Salida { get; set; }
        public DateTime TH_Refrigerio { get; set; }
        public DateTime TH_Trabajadas { get; set; }
    }
}
