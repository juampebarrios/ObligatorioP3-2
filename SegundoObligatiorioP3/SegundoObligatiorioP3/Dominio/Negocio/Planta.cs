using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Planta")]
    public class Planta
    {
        [Key]
        public int IdPlanta { get; set; }
        [Required]
        [ForeignKey("TipoPlanta")]
        public TipoPlanta MiTipoPlanta { get; set; }
        [Required]
        public string NombreCientifico { get; set; }
        [Required]
        public string NombreVulgar { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Ambiente { get; set; }
        [Required]
        public double AlturaMax { get; set; }
        [Required]
        public string Foto { get; set; }
        [Required]
        public double Precio { get; set; }
    }
}

