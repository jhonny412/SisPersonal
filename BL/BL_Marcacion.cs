using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using BL;
using System.Data;

namespace BL
{
    public class BL_Marcacion
    {
        D_Marcaciones objDMarcacion = new D_Marcaciones();
        public DataTable ListarMarcaciones()
        {
            return objDMarcacion.ListarMarcaciones();
        }
    }
}
