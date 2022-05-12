using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SearchModels.Catalogos
{
    public class CasetaSearchModel
    {
        public int Id { get; set; } = 0;
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string AliasIave { get; set; } = "";
        public int MetodoPagoId { get; set; } = 0;
        public DateTime FechaInicio { get; set; } = new DateTime(1, 1, 1);
        public DateTime FechaFin { get; set; } = new DateTime(1, 1, 1);
        
    }
}
