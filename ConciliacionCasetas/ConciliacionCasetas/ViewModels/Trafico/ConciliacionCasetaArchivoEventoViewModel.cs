namespace ConciliacionCasetas.ViewModels.Trafico
{
    public class ConciliacionCasetaArchivoEventoViewModel
    {

        public int ClaveRed { get; set; }
        public string ClaveFideicomiso { get; set; }
        public string NumeroPeriodo { get; set; }
        public string TipoPeriodo { get; set; }
        public string ClaveEmpresa { get; set; }
        public string TarjetaIDMX { get; set; }
        public string NumeroEconomico { get; set; }
        public DateTime FechaCruce { get; set; }
        public DateTime HoraCruce { get; set; }
        public int Clase { get; set; }
        public string NombreCaseta { get; set; }
        public string NombreCarril { get; set; }
        public decimal ImporteAl100 { get; set; }
        public decimal ImporteFacturado { get; set; }
        public int NumeroPlaza { get; set; }
        public string ControlInternoProveedor1 { get; set; }
        public string ControlInternoProveedor2 { get; set; }
        public string ControlInternoProveedor3 { get; set; }
        public string ControlInternoProveedor4 { get; set; }
        public int NumeroCargaBanco { get; set; }
        public DateTime FechaCargoBanco { get; set; }
        public  bool BActivo { get; set; }

        //public int Id { get; set; }
        //public DateTime FechaCruce { get; set; }
        //public string EstatusCruce { get; set; }
        //public string NumeroEconomico { get; set; }        
    }
}
