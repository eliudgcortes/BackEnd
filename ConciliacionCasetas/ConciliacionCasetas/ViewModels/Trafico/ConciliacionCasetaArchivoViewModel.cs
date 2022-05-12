namespace ConciliacionCasetas.ViewModels.Trafico
{
    public class ConciliacionCasetaArchivoViewModel
    {
        public int Id { get; set; }
        public int ConciliacionCasetaId { get; set; }
        public string ExcelArchivo { get; set; }
        public string EstatusArchivo { get; set; }
        public string Url { get; set; }
        public string Extension { get; set; }
        public bool BActivo { get; set; }
    }
}
