using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Catalogos
{
    [Table("CampoTicketCaseta", Schema = "corporativo")]
    public class CampoTicketCaseta
    {
        [Key]
        [Column("CampoTicketCasetaId")]
        public int Id { get; set; }
        public Caseta Caseta { get; set; }
        [ForeignKey("Caseta")]
        public int CasetaId { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; }
        [MaxLength(250)]
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaEdita { get; set; }
        public DateTime FechaElimina { get; set; }
        public bool BActivo { get; set; }

        public ListaGenerica? TipoDato { get; set; }
        [ForeignKey("TipoDato")]
        public int? TipoDatoId { get; set; }
    }
}
