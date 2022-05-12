namespace ProyectoMaestro.ViewModels.Catalogos
{
    public class CampoTicketCasetaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CasetaId { get; set; }
        public int TipoDatoId { get; set; }
        public bool BActivo { get; set; }
        public string NombreTipoDato { get; set; }
    }
}
