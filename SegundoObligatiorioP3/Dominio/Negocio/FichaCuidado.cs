using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio
{
    [Table("FichaCuidado")]
    public class FichaCuidado
    {
        [Key]
        public int IdFicha { get; set; }

        [Required]
        public string FrecuenciaRiego { get; set; }

        [Required]
        public string TipoIluminacion { get; set; }

        [Required]
        public int Temperatura { get; set; }

        public int IdPlanta { get; set; }

        [ForeignKey("IdPlanta")]
        public virtual Planta miPlanta { get; set; }
    }
}
