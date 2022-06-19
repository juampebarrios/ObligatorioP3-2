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
        [ForeignKey("Planta")]
        public int idPlanta { get; set; }
        public Planta UnaPlanta { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double PrecioUnitario { get; set; }
    }
}
