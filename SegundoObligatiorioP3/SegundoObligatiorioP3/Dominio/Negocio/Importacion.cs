using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Importacion")]
    public class Importacion : Compra
    {
        [Required]
        public double TasaImpuesto { get; set; }
        [Required]
        public bool EsAmericaSur { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
