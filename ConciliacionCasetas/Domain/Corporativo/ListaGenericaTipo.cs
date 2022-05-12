using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Catalogos
{
    [Table("ListaGenericaTipo", Schema = "torreservicio")]
    public class ListaGenericaTipo
    {
        
        [Key]
        [Column("ListaGenericaTipoId")]
        public int Id { get; set; }
        [Column("cveListaGenericaTipo")]
        [MaxLength(250)]
        public string Nombre { get; set; }
        [Column("desListaGenericaTipo")]
        [MaxLength(250)]
        public string Descripcion { get; set; }
        public bool BActivo { get; set; }

        public ICollection<ListaGenerica> ListaGenericas { get; set; }

    }
}
