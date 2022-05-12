using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class SamsaraGeocerca
    {


        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAtTime { get; set; }
        public string FormattedAddress { get; set; }
        public SamsaraGeocercaDetalle Geofence { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

    }

    public class SamsaraGeocercaDetalle
    {
        public SamsaraPoligono Polygon { get; set; }
    }

    public class SamsaraPoligono
    {
        public ICollection<SamsaraVertice> Vertices { get; set; }
    }

    public class SamsaraVertice
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public class ResultSamsaraGeocercaApi
    {
        public ICollection<SamsaraGeocerca> Data { get; set; }
        public SamsaraPagination Pagination { get; set; }
    }

    public class SamsaraPagination
    {
        public bool hasNextPage { get; set; }
        public string endCursor { get; set; }
    }
}
