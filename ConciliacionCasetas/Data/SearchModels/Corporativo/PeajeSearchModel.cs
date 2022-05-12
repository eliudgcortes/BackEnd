using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SearchModels.Catalogos
{
    public class PeajeSearchModel
    {
        public int CarrilId { get; set; } = 0;
        public int TipoEjeId { get; set; } = 0;
        public string Monto { get; set; } = "";
        public DateTime FechaInicio { get; set; } = new DateTime(1, 1, 1);
        public DateTime FechaFin { get; set; } = new DateTime(1, 1, 1);

    }
}
