using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Trafico
{
    [Table("ConciliacionCaseta", Schema = "trafico")]
    public class ConciliacionCaseta
    {
        [Key]
        [Column("ConciliacionCasetaId")]
        public int Id { get; set; }
        public int ClaveRed { get; set; }
        public Empresa? Empresa { get; set; }
        [ForeignKey("Empresa")]
        public int EmpresaId { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaEdita { get; set; }
        public DateTime FechaElimina { get; set; }
        //[MaxLength(80)]
        //public string? UsuarioAlta { get; set; }
        //[MaxLength(80)]
        //public string? UsuarioEdita { get; set; }
        //[MaxLength(80)]
        //public string? UsuarioElimina { get; set; }
        public DateTime FechaInicio{ get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaEstatus { get; set; }
        public string Periodo { get; set; }
        public string PeriodoProveedor { get; set; }
        public string PeriodoProveedorTipo { get; set; }
        public bool BActivo { get; set; }
        public ICollection<ConciliacionCasetaArchivo> Archivos { get; set; }
    }
}
