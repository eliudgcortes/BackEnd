using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Catalogos
{
    [Table("ListaGenerica ", Schema = "torreservicio")]
    public class ListaGenerica
    {
        [Key]
        [Column("ListaGenericaId")]
        public int Id { get; set; }
        public ListaGenericaTipo ListaGenericaTipo { get; set; }
        [ForeignKey("ListaGenericaTipo")]
        public int ListaGenericaTipoId { get; set; }
        [MaxLength(100)]
        public string? ValorString { get; set; }
        public int ValorEntero { get; set; }
        public float ValorFlotante { get; set; }
        [Required]
        [MaxLength(200)]
        [Column("cveListaGenerica")]
        public string NombreListaGenerica { get; set; }
        [MaxLength(300)]
        [Column("desListaGenerica")]
        public string DescripcionListaGenerica { get; set; }
        public int Estatus { get; set; }
        public bool BActivo { get; set; }

    }
}
