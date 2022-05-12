namespace ProyectoMaestro.ViewModels.Catalogos
{
    public class GeocercaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public PoligonoViewModel Poligono { get; set; }
        public PuntoViewModel Punto { get; set; }
        public int IdGeocercaGps { get; set; }
        public int TipoGeocerca { get; set; }
        public bool? BDireccionAzure { get; set; }
        public bool BActivo { get; set; }
        
    }
   

    public class PuntoViewModel
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }

    public class PoligonoViewModel
    {
        public string Tipo { get; set; }
        public List<PuntoViewModel> Puntos { get; set; }
    }
}
