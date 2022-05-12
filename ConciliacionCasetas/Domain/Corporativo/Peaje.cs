using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Catalogos
{
    [Table("Peaje", Schema = "corporativo")]
    public class Peaje
    {
        [Key]
        [Column("PeajeId")]
        public int Id { get; set; }
        public Carril? Carril { get; set; }
        [ForeignKey("Carril")]
        public int CarrilId { get; set; }
        [Column(TypeName = "decimal(20,4)")]
        public decimal Monto { get; set; }
        public ListaGenerica? TipoEje { get; set; }
        [ForeignKey("TipoEje")]
        public int? TipoEjeId { get; set; }
        public DateTime FechaAlta { get; set; }
        public ICollection<HistoricoPeaje> HistoricosPeaje { get; set; }
        public bool BActivo { get; set; }

    }
}
