using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Compra")]
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }
        [Required]
        public DateTime FechaCompra { get; set; }
        [Required]
        public double PrecioCompra { get; set; }
        [Required]
        [ForeignKey("PlantaComprada")]
        public List<PlantaComprada> PlantasCompradas { get; set; }
    }
}
