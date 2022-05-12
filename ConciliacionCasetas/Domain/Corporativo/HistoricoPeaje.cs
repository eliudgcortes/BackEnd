using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Catalogos
{
    [Table("HistoricoPeaje", Schema = "corporativo")]
    public class HistoricoPeaje
    {
        [Key]
        [Column("HistoricoPeajeId")]
        public int Id { get; set; }
        public Peaje Peaje { get; set; }
        [ForeignKey("Peaje")]
        public int PeajeId { get; set; }
        [Column(TypeName = "decimal(20,4)")]
        public decimal Monto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaEdita { get; set; }
        public DateTime FechaElimina { get; set; }
        public bool BActivo { get; set; }
        
    }
}
