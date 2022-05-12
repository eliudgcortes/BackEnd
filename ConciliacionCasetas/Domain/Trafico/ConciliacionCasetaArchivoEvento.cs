using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Trafico
{
    [Table("ConciliacionCasetaArchivoEvento", Schema = "trafico")]
    public class ConciliacionCasetaArchivoEvento
    {
        [Key]
        [Column("ConciliacionCasetaArchivoEventoId")]
        public int Id { get; set; }
        [MaxLength(250)]
        public ConciliacionCaseta ConciliacionCaseta { get; set; }
        [ForeignKey("ConciliacionCaseta")]
        public int ConciliacionCasetaId { get; set; }
        public string Descripcion{ get; set; }
        [MaxLength(250)]
        public int ClaveRed { get; set; }
        public string ClaveFideicomiso { get; set; }
        public string NumeroPeriodo { get; set; }
        public string TipoPeriodo { get; set; }
        [MaxLength(250)]
        public string ClaveEmpresa { get; set; }
        [MaxLength(250)]
        public string TarjetaIDMX { get; set; }
        [MaxLength(250)]
        public string NumeroEconomico { get; set; }
        [MaxLength(250)]
        public DateTime FechaCruce { get; set; }
        public DateTime HoraCruce { get; set; }
        public int Clase { get; set; }
        public string NombreCaseta { get; set; }
        [MaxLength(250)]
        public string NombreCarril { get; set; }
        [MaxLength(250)]
        public decimal ImporteAl100 { get; set; }
        public decimal ImporteFacturado { get; set; }
        public int NumeroPlaza { get; set; }
        public string ControlInternoProveedor1 { get; set; }
        public string ControlInternoProveedor2 { get; set; }
        public string ControlInternoProveedor3 { get; set; }
        public string ControlInternoProveedor4 { get; set; }
        public int NumeroCargaBanco { get; set; }
        public DateTime FechaCargoBanco { get; set; }
        public string EstatusCruce { get; set; }
        public int NumeroEconomicoSoloEntero { get; set; }
        public DateTime FechaCruceCompleta { get; set; }
        public string NombreCarrilConciliacion { get; set; }
        public string NombreClaseConciliacion { get; set; }
        public decimal ImporteConciliacion { get; set; }
        public decimal ImporteDiferencia { get; set; }
        public bool BActivo { get; set; }
    }
}
