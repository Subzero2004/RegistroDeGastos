using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiGastos.DTOs
{
    public class GastoDTO
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public decimal monto { get; set; }
        public string nombrecomercio { get; set; }
    }
}
