using Domain.Catalogos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Caseta", Schema = "corporativo")]
    public class Caseta
    {
        [Key]
        [Column("CasetaId")]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; }
        [MaxLength(250)]
        public string Descripcion { get; set; }
        [MaxLength(250)]
        public string AliasIave { get; set; }
        [MaxLength(150)]
        public string? Url { get; set; }
        public DateTime FechaAlta { get; set; }
        public ListaGenerica? MetodoPago  { get; set; }
        [ForeignKey("MetodoPago")]
        public int? MetodoPagoId { get; set; }
        public Geocerca? Geocerca { get; set; }
        [ForeignKey("GeocercaId")]
        public int? GeocercaId { get; set; }
        public DateTime FechaEdita { get; set; }
        public DateTime FechaElimina { get; set; }
        public bool BActivo { get; set; }
        public bool BCasetaActiva { get; set; }
        [MaxLength(250)]
        public string ArchivoTicketFrente { get; set; }
        [MaxLength(250)]
        public string ArchivoTicketAtras { get; set; }

        public ICollection<Carril> Carriles { get; set; }


    }
}