using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("TipoPlanta")]
    public class TipoPlanta
    {
        [Key]
        public int IdTipoPlanta { get; set; }

        [Required]
        public string NombreUnico { get; set; }

        [Required, StringLength(200, MinimumLength = 10)]
        public string DescripcionTipo { get; set; }
    }
}
