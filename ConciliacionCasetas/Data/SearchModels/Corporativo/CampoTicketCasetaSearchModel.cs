using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SearchModels.Catalogos
{
    public class CampoTicketCasetaSearchModel
    {
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public int CasetaId { get; set; } = 0;
        public int TipoDatoId { get; set; } = 0;
        public bool BActivo { get; set; }

    }
}
