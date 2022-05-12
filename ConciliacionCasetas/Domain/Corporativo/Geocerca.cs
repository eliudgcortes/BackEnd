using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Catalogos
{
    [Table("Geocerca", Schema = "corporativo")]
    public class Geocerca
    {
        [Key]
        [Column("GeocercaId")]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; }
        [MaxLength(250)]
        public string Descripcion { get; set; }
        public Geometry Poligono { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string PoligonoComputado { get; set; }
        public Point Punto { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string PuntoComputado { get; set; }
        [MaxLength(50)]
        public string GeocercaIdExterno { get; set; }
        public ListaGenerica TipoGeocerca { get; set; }
        [ForeignKey("TipoGeocerca")]
        public int? TipoGeocercaId { get; set; }
        public bool BActivo { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaEdita { get; set; }
        public DateTime FechaElimina { get; set; }
        public bool? BDireccionAzure { get; set; }
        public ICollection<Caseta> Casetas { get; set; }
    }
}
