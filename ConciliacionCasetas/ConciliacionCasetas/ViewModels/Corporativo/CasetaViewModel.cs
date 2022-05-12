namespace ProyectoMaestro.ViewModels
{
    public class CasetaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int GeocercaId { get; set; }
        public string NombreGeocerca { get; set; }
        public string AliasIave { get; set; }
        public int MetodoPagoId { get; set; } 
        public DateTime FechaAlta { get; set; }
        public bool BActivo { get; set; }
        public bool CasetaActiva { get; set; }
        public string ArchivoTicketFrente { get; set; }
        public string ArchivoTicketAtras { get; set; }
        public string NombreMetodoPago { get; set; }
        public string Url { get; set; }
    }
}
