using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SearchModels.Trafico
{
    public class ConciliacionCasetaSearchModel
    {
        public int ClaveRed { get; set; } = 0;
        public int EmpresaId { get; set; } = 0;
        public DateTime FechaInicio { get; set; } = new DateTime(1, 1, 1);
        public DateTime FechaFin { get; set; } = new DateTime(1, 1, 1);
    }
}
