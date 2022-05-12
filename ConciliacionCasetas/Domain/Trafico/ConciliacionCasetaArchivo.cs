using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Trafico
{
    [Table("ConciliacionCasetaArchivo", Schema = "trafico")]
    public class ConciliacionCasetaArchivo
    {
        [Key]
        [Column("ConciliacionCasetaArchivoId")]
        public int Id { get; set; }
        [MaxLength(250)]
        public ConciliacionCaseta? ConciliacionCaseta { get; set; }
        [ForeignKey("ConciliacionCaseta")]
        public int ConciliacionCasetaId { get; set; }
        [MaxLength(250)]
        public DateTime FechaAlta { get; set; }
        public DateTime FechaEdita { get; set; }
        public DateTime FechaElimina { get; set; }
        //[MaxLength(80)]
        //public string UsuarioAlta { get; set; }
        //[MaxLength(80)]
        //public string UsuarioEdita { get; set; }
        //[MaxLength(80)]
        //public string UsuarioElimina { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? EstatusArchivo { get; set; }
        public string? ExcelArchivo { get; set; }
        public string? Url { get; set; }
        public string? Extension { get; set; }
        public int CantidadConciliados { get; set; }
        public int CantidadConDiferencia { get; set; }
        public decimal TotalSinDiferencia { get; set; }
        public decimal TotalConDiferencia { get; set; }
        public bool BActivo { get; set; }
        public ICollection<ConciliacionCasetaArchivoEvento> Eventos { get; set; }
    }
}
