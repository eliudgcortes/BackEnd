using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.TableModels.Catalogos
{
    public class GeocercaTableModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdGeocercaGps { get; set; }
        public int TipoGeocerca { get; set; }
    }
}
