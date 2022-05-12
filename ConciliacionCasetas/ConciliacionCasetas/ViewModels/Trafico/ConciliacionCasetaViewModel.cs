namespace ConciliacionCasetas.ViewModels.Trafico
{
    public class ConciliacionCasetaViewModel
    {
        public int Id { get; set; }
        public int ClaveRed { get; set; }
        public int EmpresaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool BActivo { get; set; }
    }
}
