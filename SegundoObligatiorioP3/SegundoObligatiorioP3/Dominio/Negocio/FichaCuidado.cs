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
        public int idFicha { get; set; }
        [Required]
        public string FrecuenciaRiego { get; set; }
        [Required]
        public string TipoIluminacion { get; set; }
        [Required]
        public int Temperatura { get; set; }
        [Required]
        [ForeignKey("Planta")]
        public Planta miPlanta { get; set; }
    }
}
