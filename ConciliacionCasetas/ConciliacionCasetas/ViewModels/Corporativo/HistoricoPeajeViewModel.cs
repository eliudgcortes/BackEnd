namespace ProyectoMaestro.ViewModels.Catalogos
{
    public class HistoricoPeajeViewModel
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaEdita { get; set; }
        public DateTime FechaElimina { get; set; }
        public bool BActivo { get; set; }
    }
}
