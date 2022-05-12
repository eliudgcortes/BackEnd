using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SearchModels.Trafico
{
    public class ConciliacionCasetaArchivoEventoSearchModel
    {
        public int Id { get; set; } = 0;
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string ClaveEmpresa { get; set; } = "";
        public DateTime FechaCruce { get; set; } = new DateTime(1, 1, 1);

    }
}
