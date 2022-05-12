namespace ProyectoMaestro.ViewModels
{
    public class ListaGenericaViewModel
    {
        public int Id { get; set; }
        public int ListaGenericaTipoId { get; set; }
        public string ValorString { get; set; }
        public int ValorEntero { get; set; }
        public float ValorFlotante { get; set; }
        public string NombreListaGenerica { get; set; }
        public string DescripcionListaGenerica { get; set; }
        public int Estatus { get; set; }
        public bool BActivo { get; set; }
    }
}
