using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Catalogos
{
    [Table("Carril", Schema = "corporativo")]
    public class Carril
    {
        [Key]
        [Column("CarrilId")]
        public int Id { get; set; }
        [MaxLength(250)]
        public Caseta Caseta { get; set; }
        [ForeignKey("Caseta")]
        public int CasetaId { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; }
        [MaxLength(250)]
        public string Descripcion { get; set; }
        [MaxLength(150)]
        public string  AliasIave    { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaEdita { get; set; }
        public DateTime FechaElimina { get; set; }
        public bool BActivo { get; set; }
       

        public ICollection<Peaje> Peajes { get; set; }

        

    }
}
