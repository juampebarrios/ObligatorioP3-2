using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Plaza")]
    public class Plaza : Compra
    {

        [Required]
        public bool Flete { get; set; }
        [Required]
        public double Iva { get; set; }
    }
}
