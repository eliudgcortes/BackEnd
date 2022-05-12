namespace ProyectoMaestro.ViewModels.Catalogos
{
    public class CarrilViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string AliasIave { get; set; }
        public int CasetaId { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool BActivo { get; set; }
        public ICollection<PeajeViewModel> Peajes { get; set; }

    }
}
