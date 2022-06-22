using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("PlantaComprada")]
    public class PlantaComprada
    {
        [Key]
        public int IdPlantaComprada { get; set; }

        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double PrecioUnitario { get; set; }
        
        [ForeignKey("IdCompra")]
        public int IdCompra { get; set; }

        //[NotMapped]
        //public Compra miCompra { get; set; }


        [ForeignKey("IdPlanta")]
        public int IdPlanta { get; set; }


        //[NotMapped]
        //public Planta UnaPlanta { get; set; }
    }
}
