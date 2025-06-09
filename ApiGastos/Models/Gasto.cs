using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiGastos.Models
{
    public class Gasto
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required]
        [StringLength(250)]
        [MinLength(3)]
        public string Descripcion { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a cero")]
        public decimal Monto { get; set; }
        [Required]
        [StringLength(250)]
        [MinLength(1)]
        public string NombreComercio { get; set; }
    }
}
