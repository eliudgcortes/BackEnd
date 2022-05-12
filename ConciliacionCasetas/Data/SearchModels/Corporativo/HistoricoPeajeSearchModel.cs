using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SearchModels.Catalogos
{
    public class HistoricoPeajeSearchModel
    {
        public int Id { get; set; }= 0;
        public string Monto { get; set; }= "";
        public int PeajeId { get; set; } = 0;
        public DateTime FechaInicio { get; set; } = new DateTime(1, 1, 1);
        public DateTime FechaFin { get; set; } = new DateTime(1, 1, 1);
    }
}
