namespace ProyectoMaestro.ViewModels.Catalogos
{
    public class PeajeViewModel
    {
        public int Id { get; set; }
        public string NombreCarril { get; set; }
        public int CarrilId { get; set; }
        public decimal Monto { get; set; }
        public string NombreTipoEje { get; set; }
        public int TipoEjeId { get; set; }
        public bool BActivo { get; set; }
    }
}
