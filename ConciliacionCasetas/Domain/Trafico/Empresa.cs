using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Trafico
{
    [Table("Empresa ", Schema = "corporativo")]
    public class Empresa
    {
        [Key]
        [Column("EmpresaId")]
        public int Id { get; set; }
        [MaxLength(150)]

        [Column("cveEmpresa")]
        public string Nombre { get; set; }
        [MaxLength(150)]

        [Column("desEmpresa")]
        public string Descripcion { get; set; }

        [Column("IdEmpresaSip")]
        public int EmpresaSipId { get; set; }
        [MaxLength(1000)]

        [Column("Logo")]
        public string Logo { get; set; }

        [Column("bActivo")]
        public bool BActivo { get; set; }
    }
}
