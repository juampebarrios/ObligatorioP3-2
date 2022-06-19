using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Compra")]
    public abstract class Compra
    {
        [Key]
        public int IdCompra { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime FechaCompra { get; set; }
        [Required]
        public double PrecioCompra { get; set; }


        [NotMapped]
        public List<PlantaComprada> PlantasCompradas { get; set; }
    }
}
